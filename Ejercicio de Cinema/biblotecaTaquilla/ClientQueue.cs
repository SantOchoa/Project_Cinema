using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblotecaTaquilla
{
    public class ClientQueue
    {
        public Queue<Client> clientsqueue { get; set; }

        public ClientQueue()
        {
            clientsqueue = new Queue<Client>();
        }
        public ClientQueue(Queue<Client> clientsqueue)
        {
            this.clientsqueue = clientsqueue;
        }
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Client client in clientsqueue)
            {
                sb.Append(client.toString() + "\n");
            }
            return sb.ToString();
        }
        public void enqueueClient(Client client)
        {
            clientsqueue.Enqueue(client);
        }
        public void removeClient()
        {
            clientsqueue.Dequeue();
        }
        
    }
}
