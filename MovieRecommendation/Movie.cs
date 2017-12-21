using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation
{
    class Movie
    {

        #region Properties
        private string movieID;

        public string MovieID
        {
            get { return movieID; }
            set { movieID = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private List<double> rating = new List<double>();

        public List<double> Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        #endregion

        public Movie(string id, string title, string genres)
        {
            MovieID = id;
            Title = title;
            Genre = genres;
        }

        public void AddNewRating(double rating)
        {

            this.rating.Add(rating);
        }

        public double GetAverageRating()
        {
            return rating.Average();
        }
    }
}
