using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblotecaConfiteria
{
    public class RegPurchase
    {
        public Stack<Purchase> purchases { get; set; }

        public RegPurchase() 
        {
            purchases = new Stack<Purchase>();
        }
        public RegPurchase(Stack<Purchase> purchases)
        {
            this.purchases = purchases;
        }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Purchase purchase in purchases)
            {
                sb.Append(purchase.toString() + "\n\n----------------------------------------------------------\n");
            }
            return sb.ToString();
        }
        public void pushPruchase(Purchase purchase)
        {
            purchases.Push(purchase);
        }
    }
}
