using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataOrders.Data
{
    public class ODataOrdersContext : DbContext
    {
        public ODataOrdersContext(DbContextOptions<ODataOrdersContext> context)
            : base(context) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
