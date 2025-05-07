using System.Text;
using biblotecaCartelera;

namespace biblotecaSalas
{
    public class Room
    {
        private static int numbercounter = 0;
        public int numberRoom { get; set; }
        public int[,] numberseats { get; set; }
        public Movie movie { get; set; }


        public Room()
        {
            numbercounter++;
            numberRoom = numbercounter;
            numberseats = new int[10, 10];
            ;

        }
        public Room(Movie movie)
        {
            this.numberRoom = numberRoom++;
            this.movie = movie;
        }
        public string toString()
        {
            if (movie == null)
            {
                return ($"Numero de Sala: {numberRoom}");
            }
            else
            {
                return ($"Numero de Sala: {numberRoom}, Disponibilidad: {(calculateCapacity() / 100) * 100}%, Pelicula asignada: {movie.name}");
            }
        }
        public string showSeats()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n  \t");
            for (int col = 0; col < numberseats.GetLength(1); col++)
            {
                sb.Append($"{col} ");

            }
            sb.Append("\n");
            sb.Append("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            sb.AppendLine("\n");
            for (int i = 0; i < numberseats.GetLength(0); i++)
            {
                sb.Append($"{i}|\t");

                for (int j = 0; j < numberseats.GetLength(1); j++)
                {
                    sb.Append(numberseats[i, j]);
                    sb.Append(" ");
                }
                sb.Append('\n');
            }
            sb.Append("  \t----------------------");
            sb.Append("\n  \t       PANTALLA       \n");
            sb.Append("\n0 - LIBRE\n1 - OCUPADO");
            return sb.ToString();
        }
        public bool reserveSeat(int i, int j)
        {
            for (int k = 0; k < numberseats.GetLength(0); k++)
            {
                for (int l = 0; l < numberseats.GetLength(1); l++)
                {
                    if (k == i && l == j)
                    {
                        if (numberseats[k, l] == 0)
                        {
                            numberseats[k, l] = 1;
                            return true;
                        }
                        break;
                    }
                }
            }
            return false;
        }
        public double calculateCapacity()
        {
            double capacity = 0;
            for (int i = 0; i < numberseats.GetLength(0); i++)
            {

                for (int j = 0; j < numberseats.GetLength(1); j++)
                {
                    if (numberseats[i, j] == 0)
                    {
                        capacity = capacity + 1;
                    }
                }
            }
            return capacity;
        }
        public void setMovie(Movie movie)
        {
            this.movie = movie;
        }
        public string showCapcity()
        {
            if (movie == null)
            {
                return $"Numero de Sala: {numberRoom}, Disponibilidad: {(calculateCapacity() / 100) * 100}%, Asientos ocupados: {100 - calculateCapacity()} de 100, Pelicula asignada: Ninguna";
            }
            return $"Numero de Sala: {numberRoom}, Disponibilidad: {(calculateCapacity()/100)*100}%, Asientos ocupados: {100-calculateCapacity()} de 100, Pelicula asignada: {movie.name}";
        }

    }
}
