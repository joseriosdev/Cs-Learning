using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_MovieFilter.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Country Country { get; set; }
        public Genre[] Genre { get; set; }
    }
}
