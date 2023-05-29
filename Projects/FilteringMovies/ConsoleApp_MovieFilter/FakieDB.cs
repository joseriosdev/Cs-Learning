using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_MovieFilter.Models;
using Microsoft.VisualBasic;

namespace ConsoleApp_MovieFilter
{
    internal class FakieDB
    {
        public static List<Movie> GetFakieData()
        {
            var drama = new Genre { Id = 0, Name = "Drama" };
            var action = new Genre { Id = 1, Name = "Action" };
            var comedy = new Genre { Id = 2, Name = "Comedy" };
            var adventure = new Genre { Id = 3, Name = "Adventure" };
            //
            var col = new Country { Id = 0, Name = "Colombia" };
            var bol = new Country { Id = 1, Name = "Bolivia" };
            var arg = new Country { Id = 2, Name = "Argentina" };

            return new List<Movie>() {
                new Movie{ Id = 0, Name = "Terminator", Genre = new Genre[] { action },  Country = col },
                new Movie{ Id = 0, Name = "Tarzan", Genre = new Genre[] { adventure,comedy},  Country = bol },
                new Movie{ Id = 0, Name = "Titanic", Genre = new Genre[] {drama },  Country = bol },
                new Movie{ Id = 0, Name = "How to train your dragon", Genre = new Genre[] {adventure },  Country = col },
                new Movie{ Id = 0, Name = "I am legend", Genre = new Genre[] {drama,action,adventure },  Country = arg },
                new Movie{ Id = 0, Name = "Saving private Ryan", Genre = new Genre[] {drama,action },  Country = col },
                new Movie{ Id = 0, Name = "El Zorro", Genre = new Genre[] {adventure },  Country = arg },
                new Movie{ Id = 0, Name = "La la land", Genre = new Genre[] { drama},  Country = bol },
                new Movie{ Id = 0, Name = "Happy Gilmore", Genre = new Genre[] {comedy },  Country = col },
                new Movie{ Id = 0, Name = "Click", Genre = new Genre[] {comedy,adventure },  Country = col },
                new Movie{ Id = 0, Name = "500 days of Summer", Genre = new Genre[] { comedy,drama},  Country = arg }
            };
        }
    }
}
