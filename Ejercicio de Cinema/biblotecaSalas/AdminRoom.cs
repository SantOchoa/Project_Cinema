using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblotecaCartelera;

namespace biblotecaSalas
{
    public class AdminRoom
    {
        public LinkedList<Room> roomList { get; set; }

        public AdminRoom() 
        {
            roomList = new LinkedList<Room>();
        }
        public AdminRoom(LinkedList<Room> roomList)
        {
            this.roomList = roomList;
        }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Room room in roomList)
            {
                sb.Append(room.toString() + "\n");
            }
            return sb.ToString();
        }
        public string toStringnotbusy()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Room room in roomList)
            {
                if (room.movie == null)
                {
                    if(room.calculateCapacity() == 100)
                    {
                        sb.Append(room.toString() + "\n");

                    }
                }
            }
            return sb.ToString();
        }

        public void addRoom(Room room)
        {
            roomList.AddLast(room);
        }
        public void setMovieRoom (Movie movie, int numberRoom)
        {
            foreach (Room room in roomList)
            {
                if (room.numberRoom == numberRoom)
                {
                    room.movie = movie;
                    break;
                }
            }
        }
        public string getRoomfree(Movie movie)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Room room in roomList)
            {
                if (room.movie == movie)
                {
                    sb.Append(room.toString() + "\n");
                }
            }
            return sb.ToString();
        }
        public Room getRoombyNumberroom(int numberRoom)
        {
            foreach(Room room in roomList)
            {
                if (room.numberRoom == numberRoom) 
                { 
                    return room;
                }
            }
            return null;
        }
        public string showCapacityofRooms()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Room room in roomList)
            {
                sb.Append(room.showCapcity()+"\n");
            }
            return sb.ToString();
        }
        public void removeMovie(string moviename)
        {
            foreach (Room room in roomList)
            {
                if (room.movie != null)
                {
                    if (room.movie.name.Equals(moviename))
                    {
                        room.movie = null;
                        room.numberseats = new int[10, 10]; 
                    }
                }
            }
        }
        public bool verificateMovieinroom(int numberRoom)
        {
            foreach (Room room in roomList)
            {
                if(room.numberRoom == numberRoom)
                {
                    if( room.movie == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
