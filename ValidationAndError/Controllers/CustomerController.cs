using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidationAndError.Filters;
using ValidationAndError.Models;

namespace ValidationAndError.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Create a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>customer</returns>
        /// <response code="200">If Customer is saved.</response>
        /// <reponsse code="400"> If customer validation fail.</reponsse>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Envelope), 400)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            // no model validation here

            return Ok(customer);
        }
    }
}