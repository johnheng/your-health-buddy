using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperCoolTest
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "Hello", "Hello", "Hello", "Heldlo", "Hello", "Heasdfasdfasdfllo", "Hello", "Hello", "Hello", "Hello", "Hello", "Hello", "Hello", "Wodrld" };
        }
    }
}
