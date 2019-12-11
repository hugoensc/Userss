using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Userss.Controllers
{
    [Route("/Name")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost]
        //[HttpGet]
        [Route("/Name/Hugo")]
        public IActionResult Index(string data, int age)
        {
            //ViewData["id"] = data + " " + age;
            String datas = data + " " + age;
            return View("Index", datas);
        }

    } 
}