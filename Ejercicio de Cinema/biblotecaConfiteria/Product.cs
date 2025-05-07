using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblotecaConfiteria
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public Product() 
        {

        }
        public Product(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
        public string toString()
        {
            return ($"Id: {id}, Nombre producto: {name}, Precio: ${price}");
        }



    }
}
