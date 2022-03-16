using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace files
{
    public class Movie
    {
        public string Title { get; set; }   
        public int InTopTen { get; set; } 

        public Movie(string Title)
        {
            this.Title = Title;
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(File.OpenRead("netflix.csv"));
            List<Movie> Movies = new List<Movie>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var values = line.Split(',');
                Movie m = Movies.Find(x => x.Title == values[4]);
                if (m == null)
                {
                    m = new Movie(values[4]);
                    m.InTopTen = 1;
                    Movies.Add(m);
                }
                else
                {
                    m.InTopTen++;
                }
                
            }

            foreach(var Movie in Movies)
            {
                Console.WriteLine(Movie.Title + " " + Movie.InTopTen);
            }
        }
    }
}
