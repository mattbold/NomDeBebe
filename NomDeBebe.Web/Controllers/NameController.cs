using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NomDeBebe.Application.UseCases.BabyNames;

namespace NomDeBebe.Controllers
{
    [Produces("application/json")]
    [Route("api/names")]
    public class NameController : Controller
    {

        private IBabyNameInteractor babyNameInteractor;

        public NameController(IBabyNameInteractor babyNameInteractor)
        {
            this.babyNameInteractor = babyNameInteractor;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetNames()
        {
            var names = new List<string>();

            names.Add("james");
            names.Add("billy");

            return Ok(names);
        }

        [HttpGet]
        [Route("search/{name}")]
        public IActionResult SearchName(string name)
        {
            var response = this.babyNameInteractor.NameSearch(name);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddNames()
        {
            return Ok();
        }
    }
}