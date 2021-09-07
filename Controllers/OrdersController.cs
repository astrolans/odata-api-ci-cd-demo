using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataOrders.Controllers
{
    public class OrdersController : ODataController
    {
        private readonly Repository repo;

        public OrdersController(Repository reppo)
        {
            this.repo = reppo;
        }

        [EnableQuery]
        public IActionResult Get() => Ok(repo.Orders);

        public IActionResult Post([FromBody] Order c)
        {
            repo.Orders.Add(c);
            return Ok(c);
        }
    }
}
