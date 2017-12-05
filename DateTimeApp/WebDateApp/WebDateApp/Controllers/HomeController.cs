using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDateApp.Models;
using WebTestApp;
using WebDateApp.Context;

namespace WebDateApp.Controllers
{
    [Route("/api/Home")]
    public class HomeController : Controller
    {
        private DateTimeContext db;
        public HomeController(DateTimeContext context)
        {
            db = context;
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]DateTimeModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.DTModels.Add(value);
            db.SaveChanges();
            return Ok();            
        }
    }

}
