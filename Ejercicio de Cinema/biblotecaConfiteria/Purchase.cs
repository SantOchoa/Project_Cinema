using System.Text;

namespace biblotecaConfiteria
{
    public class Purchase
    {
        public int idclient { get; set; }
        public ProductsList products{ get; set; }
        public double total { get; set; }

        public Purchase() 
        {
            
        }
        public Purchase(int idclient, ProductsList products, double total)
        {
            this.idclient = idclient;
            this.products = products;
            this.total = total;
        }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Product product in products.products)
            {
                sb.Append(product.toString() + "\n");
            }

            return ($"Id del Cliente: {idclient}\n Productos:\n {sb.ToString()}\nTotal: ${total}");
        }
        public string showProducts()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Product product in products.products)
            {
                sb.Append(product.toString());
            }
            return sb.ToString();
        }
    }
}
