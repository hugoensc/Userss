using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Userss.Controllers
{
    public class UsersController : Controller
    {
        // [HttpPost]
        // [HttpGet]
        public IActionResult Index(string data, int age)
        {
            //ViewData["id"] = data + " " + age;
            String datos = data + " " + age;
            return View("Index", datos);
        }
    } 
}