using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace MovieRecommendation
{
    class Menu
    {

        #region Variables
        List<Movie> movies = new List<Movie>();

        string path = Path.Combine(Environment.CurrentDirectory, @"Datasets\ratings.csv");
        string path2 = Path.Combine(Environment.CurrentDirectory, @"Datasets\movies.csv");
        #endregion

        public Menu()
        {
            Console.WriteLine("Please enter what genre you want to search for, example: Action, Drama, or Comedy");
            string search = Console.ReadLine();
            MovieReader(search);
            GetRatings();

            PrintMovies();
            //LINQMovieReader(search);
        }

        private void MovieReader(string search)
        {
            using (TextFieldParser parser = new TextFieldParser(path2))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();

                    //Write one row
                    if (fields[2].Contains(search))
                    {
                        movies.Add(new Movie(fields[0], fields[1], fields[2]));
                    }
                }
            }
        }

        private void GetRatings()
        {
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach(Movie movie in movies)
                    {
                        if (movie.MovieID.Equals(fields[1]))
                        {

                            movie.AddNewRating(Convert.ToDouble(fields[2]));

                        }
                    }
                }
            }
        }

        private void LINQMovieReader(string search)
        {
            using (TextFieldParser parser = new TextFieldParser(path2))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.HasFieldsEnclosedInQuotes = true;


               parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    var query =
                        from reader in parser.ReadFields()
                        where reader.Contains(search)
                        select reader;
                    
                    try
                    {
                        movies.Add(new Movie(query.ElementAt(0), query.ElementAt(1), query.ElementAt(2)));
                    }
                    catch { }
                }

                foreach (Movie movie in movies)
                {
                    Console.WriteLine("{0} {1} {2}",movie.MovieID, movie.Title, movie.Genre);
                }
                


                //var query =
                //    from reader in search
                //    let elements = search.Split(',')
                //    let result = elements.Skip(1)
                //    select (from searched in result
                //            select searched);
                //
                //var results = query.ToList();

            }

        }

        private void PrintMovies()
        {
            foreach (Movie movie in movies)
            {
                try
                {
                    Console.WriteLine("ID:{0} Title:{1} Genres:{2} Ratings:{3}", movie.MovieID, movie.Title, movie.Genre, Math.Round(movie.GetAverageRating(), 2));
                }
                //If a movie have no ratings:
                catch
                {
                    Console.WriteLine("ID:{0} Title:{1} Genres:{2} Ratings: No Rating", movie.MovieID, movie.Title, movie.Genre);
                }
            }
        }
    }
}
