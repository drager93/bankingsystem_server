using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankingSystem_server.Models;
using bankingSystem_server.Database;

namespace bankingSystem_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public DBContext DBContext { get; }

        public HomeController(DBContext dbContext)
        {
            DBContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var a = DBContext.User.ToList();
            return Ok(a);
        }
    }
}
