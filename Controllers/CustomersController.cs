using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataOrders.Controllers
{
    // Not needed with OData
    //[Route("api/[controller]")]
    //[ApiController]

    // ControllerBase not needed w/ OData
    //public class CustomersController : ControllerBase

    public class CustomersController : ODataController
    {
        private readonly ODataOrdersContext context;

        public CustomersController(ODataOrdersContext context)
        {
            this.context = context;
        }

        // Change attribute, remove async, Task and await.
        // Not returning a List, but a reference to Customers (DbSet).
        // OData in charge of builder the query (the client in charge?)

        //[HttpGet]
        [EnableQuery]
        public IActionResult Get() => Ok(context.Customers);

        //[HttpPost]
        public IActionResult Add([FromBody] Customer c)
        {
            context.Customers.Add(c);
            context.SaveChanges();
            return Ok(c);
        }

        /// <summary>
        /// Seed data to localDb.
        /// </summary>
        /// <returns>Http status code 200</returns>
        [HttpPost]
        [Route("fill")]
        public async Task<IActionResult> Fill()
        {
            Random rand = new();

            for (int i = 0; i < 10; i++)
            {
                Customer c = new()
                {
                    CustomerName = demoCustomers[rand.Next(demoCustomers.Count)],
                    CountryId = demoCountries[rand.Next(demoCountries.Count)]
                };
                await context.Customers.AddAsync(c);

                for (int j = 0; j < 10; j++)
                {
                    Order o = new()
                    {
                        OrderDate = DateTime.Today,
                        Product = demoProducts[rand.Next(demoProducts.Count)],
                        Quantity = rand.Next(1, 5),
                        Revenue = rand.Next(100, 5000),
                        Customer = c
                    };
                    await context.Orders.AddAsync(o);
                }
            }
            await context.SaveChangesAsync();
            return Ok();
        }

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
