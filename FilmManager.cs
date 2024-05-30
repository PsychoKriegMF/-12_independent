using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace С_12_independent
{
    public class FilmManager
    {
         public List<Film> FilmCollection = new List<Film>();
         public void AddFilm(Film film)
        {
            FilmCollection.Add(film);
        }
        public void DellFilm(string name)
        {
            FilmCollection.RemoveAll(p => p.Name == name);
        }
        public IEnumerable<Film> SearchFilm(string name)
        {
            return FilmCollection.Where(p => p.Name == name);
        }
        public IEnumerable<Film> SearchFilmGenre(string genre)
        {
            return FilmCollection.Where(p => p.Genre == genre);
        }
        public IEnumerable<Film> SearchFilmDirector(string director)
        {
            return FilmCollection.Where(p => p.Director == director);
        }

        public void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(FilmCollection);
            File.WriteAllText(path, json);
        }
        public void LoadFromJson(string path)
        {
            string json = File.ReadAllText(path);
            FilmCollection = JsonConvert.DeserializeObject<List<Film>>(json);
        }
        public void SaveToXml(string path)
        {
            XElement xml = new XElement("Films",
                from film in FilmCollection
                select new XElement("Film",
                new XAttribute("Name", film.Name),
                new XAttribute("Genre", film.Genre),
                new XAttribute("Director", film.Director),
                new XAttribute("YearOfRelease", film.Year)
                ));
            xml.Save(path);
        }
        public void LoadFromXml(string path)
        {            
            XDocument xml = XDocument.Load("Film.xml");
            FilmCollection = xml.Descendants("Film").Select(p => new Film
            {
                Name = p.Attribute("Name").Value,
                Genre = p.Attribute("Genre").Value,
                Director = p.Attribute("Director").Value,
                Year = int.Parse(p.Attribute("YearOfRelease").Value)
            }).ToList();
        }

    }
}
