using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblotecaCartelera
{
    public class BulletinBoard
    {
        public ArrayList movieArray { get; set; }

        public BulletinBoard()
        {
            movieArray = new ArrayList();
        }
        public BulletinBoard(ArrayList movieArray)
        {
            this.movieArray = movieArray;
        }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Movie movie in movieArray)
            {
                sb.Append(movie.toString() + "\n\n");
            }
            return sb.ToString();
        }
        public void addMovie(Movie movie)
        {
            movieArray.Add(movie);
        }
        public Movie getMoviebyName(string name)
        {
            foreach (Movie movie in movieArray)
            {
                if (movie.name.Equals(name))
                {
                    return movie;
                }
            }
            return null;
        }
        public void deleteMovie(string name)
        {
            for (int i = 0; i < movieArray.Count; i++)
            {
                Movie movie = (Movie)movieArray[i];
                if (movie.name.Equals(name))
                {
                    movieArray.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
