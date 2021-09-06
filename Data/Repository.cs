using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ODataOrders.Data
{
    public class Repository
    {
        public List<Customer> Customers { get; set; }
        
        private List<Order> Orders { get; set; }

        public Repository()
        {
            LoadData();
            Fill();
        }

        private void LoadData()
        {
            var customersFile = File.ReadAllText("customers.json");
            var ordersFile = File.ReadAllText("orders.json");

            Customers = JsonSerializer.Deserialize<Customer[]>(customersFile).ToList();
            Orders = JsonSerializer.Deserialize<Order[]>(ordersFile).ToList();
        }

        private void Fill()
        {
            Random rand = new();

            foreach (var customer in Customers)
            {
                for (int i = 0; i < rand.Next(1, 11); i++)
                {
                    int k = rand.Next(Orders.Count);
                    if (Orders[k].CustomerId != 0) continue;
                    customer.Orders.Add(Orders[k]);
                    Orders[k].CustomerId = customer.Id;
                }
            }
        }
    }
}
