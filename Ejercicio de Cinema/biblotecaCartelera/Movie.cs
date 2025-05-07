namespace biblotecaCartelera
{
    public class Movie
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int time { get; set; }
        public string classification { get; set; }
        public double hour { get; set; }

        
        public Movie(string name, string gender, int time, string classification, double hour)
        {
            this.name = name;
            this.gender = gender;
            this.time = time;
            this.classification = classification;
            this.hour = hour;
        }
        public string toString()
        {
            return ($"Nombre: {name}          Genero: {gender}\nDuracion: {time}          Hora de funcion: {hour}\nClasificaion: {classification}");
        }
    }
}
