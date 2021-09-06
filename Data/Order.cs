using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataOrders.Data
{
    public class Order
    {
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public string Movie { get; set; }
        
        public string Genre { get; set; }
        
        public int Quantity { get; set; }
        
        public int Price { get; set; }
        
        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }
    }
}
