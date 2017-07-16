using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NomDeBebe.Controllers
{
    [Produces("application/json")]
    [Route("api/names")]
    public class NameController : Controller
    {
        [HttpGet]
        [Route("all")]
        public IActionResult GetNames()
        {
            var names = new List<string>();

            names.Add("james");
            names.Add("billy");

            return Ok(names);
        }

        [HttpPost]
        public IActionResult AddNames()
        {
            return Ok();
        }
    }
}