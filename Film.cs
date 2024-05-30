using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_12_independent
{
    public class Film : IFilm
    {
        public  string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
    }
}
