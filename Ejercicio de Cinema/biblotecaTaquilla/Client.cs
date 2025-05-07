using biblotecaSalas;

namespace biblotecaTaquilla
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Room room { get; set; }
        public int seatfila { get; set; }
        public int seatcolum { get; set; }

        public Client() { }
        public Client(int id, string name, int age, Room room)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.room= room;
        }
        public string toString()
        {
            return ($"Nombre: {name}, ID: {id}, Edad: {age}, Pelicula seleccionada: {room.movie.name}");
        }
    }
}
