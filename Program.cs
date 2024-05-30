namespace С_12_independent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilmManager catalog = new FilmManager();
            catalog.AddFilm(new Film { Name = "Terminator", Genre = "Action", Director = "HZ", Year = 1800 });
            catalog.AddFilm(new Film { Name = "Zxcvbn", Genre = "nbvcxz", Director = "HwZ", Year = 2024 });
            catalog.AddFilm(new Film { Name = "Qwerty", Genre = "ytrewq", Director = "HZg", Year = 1697 });

            catalog.SaveToJson("film.json");
            catalog.LoadFromJson("film.json");
            Console.WriteLine("Json");
            foreach(var i in catalog.FilmCollection)
            {
                Console.WriteLine($"Name: {i.Name}, Genre: {i.Genre}, Director: {i.Director}, Year: {i.Year}");
            }

            Console.WriteLine("xml");
            catalog.SaveToXml("film.xml");
            catalog.LoadFromXml("film.xml");
            foreach (var i in catalog.FilmCollection)
            {
                Console.WriteLine($"Name: {i.Name}, Genre: {i.Genre}, Director: {i.Director}, Year: {i.Year}");
            }

            Console.WriteLine();
            Console.WriteLine("Ganre");
            //фильтрация продуктов по категориям
            IEnumerable<Film> FilteredFilmGanre = catalog.SearchFilmGenre("Action");
            foreach (var i in FilteredFilmGanre)
            {
                Console.WriteLine($"Name: {i.Name}, Genre: {i.Genre}, Director: {i.Director}, Year: {i.Year}");
            }
            IEnumerable<Film> FilterFilmDirector = catalog.SearchFilmDirector("HZ");
            foreach (var i in FilterFilmDirector)
            {
                Console.WriteLine($"Name: {i.Name}, Genre: {i.Genre}, Director: {i.Director}, Year: {i.Year}");
            }

        }
    }
}
