using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_MovieFilter.Models;
using BetterConsoleTables;

namespace ConsoleApp_MovieFilter
{
    internal class AppController
    {
        private static List<Movie> _movies = FakieDB.GetFakieData();

        public static void Run()
        {
            FilterByName("Tarzan");
        }

        private static void FilterByName(string name)
        {
            IEnumerable<Movie> query = _movies.Where(movie => movie.Name == name);
            Console.WriteLine("---- Filtering by Name ----");
            Console.WriteLine($"Name = '{name}'");
            var table = new Table("Name","Year","Country","Genre");
            foreach(Movie movie in query) table.AddRow(movie.Name, movie.Year, movie.Country.Name, movie.Genre);
            Console.WriteLine(table);
        }

    }
}
