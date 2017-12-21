using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation
{
    class Rating
    {
        private int userId;

        public int UserID
        {
            get { return userId; }
            set { userId = value; }
        }
        private int movieId;

        public int MovieID
        {
            get { return movieId; }
            set { movieId = value; }
        }
        private float rating;

        public float Ratings
        {
            get { return rating; }
            set { rating = value; }
        }
        private int timeStamp;

        public int TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        public Rating(int userId, int movieId, float rating, int timeStamp)
        {
            this.UserID = userId;
            this.MovieID = movieId;
            this.Ratings = rating;
            this.TimeStamp = timeStamp;
        }

    }
}
