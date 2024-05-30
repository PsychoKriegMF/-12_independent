using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_12_independent
{
    public interface IFilm
    {
        string Name { get; }
        string Genre {  get; }
        string Director { get; }
        int Year {  get; }
    }
}
