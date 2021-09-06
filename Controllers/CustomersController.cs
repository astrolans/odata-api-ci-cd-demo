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
    public class CustomersController : ODataController
    {
        private readonly Repository repo;

        public CustomersController(Repository repo)
        {
            this.repo = repo;
        }

        [EnableQuery]
        public IActionResult Get() => Ok(repo.Customers);

        public IActionResult Post([FromBody] Customer c)
        {
            repo.Customers.Add(c);
            return Ok(c);
        }
    }
}
