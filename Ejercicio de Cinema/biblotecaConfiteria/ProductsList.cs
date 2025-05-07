using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblotecaConfiteria
{
    public class ProductsList
    {
        public List<Product> products { get; set; }
        public ProductsList() 
        {
            products = new List<Product>();
        }
        public string showProducts()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Product product in products)
            {
                sb.Append(product.toString()+"\n");
            }
            return sb.ToString();
        }
        public void addProduct(Product product)
        {
            products.Add(product);
        }
        public Product searchProductById(int id)
        {
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    return product;
                    break;
                }
            }
            return null;
        }
        public int calculateTotal(ProductsList products)
        {
            int total= 0;
            foreach (Product product in products.products)
            {
                total = total+ product.price;
            }            
            return total;
        }

    }
}
