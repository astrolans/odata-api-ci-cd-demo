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
        private Order[] _orders;

        public Repository()
        {
            var customersFile = File.ReadAllText("customers.json");
            var ordersFile = File.ReadAllText("orders.json");

            Customers = JsonSerializer.Deserialize<Customer[]>(customersFile).ToList();
            _orders = JsonSerializer.Deserialize<Order[]>(ordersFile);
        }

        #region Seed database
        /// <summary>
        /// <strike>Seed data to localDb.</strike>
        /// </summary>
        /// <returns>Http status code 200</returns>
        public void Fill()
        {
            Random rand = new();

            foreach (var customer in Customers)
            {
                for (int i = 0; i < rand.Next(1, 11); i++)
                {
                    int k = rand.Next(_orders.Length);
                    customer.Orders.Add(_orders[k]);
                    _orders[k].CustomerId = customer.Id;
                }
            }
        }
        #endregion

        #region Data
        private List<string> demoCustomers = new()
        {
            "Foo",
            "Bar",
            "Acme",
            "King of Tech",
            "Awesomeness"
        };

        private readonly List<string> demoProducts = new()
        {
            "Bike",
            "Car",
            "Apple",
            "Spaceship"
        };

        private readonly List<string> demoCountries = new()
        {
            "AT",
            "DE",
            "CH"
        };
        #endregion
    }
}
