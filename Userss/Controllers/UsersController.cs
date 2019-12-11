using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Userss.Controllers
{
    //[Route("/Users")]
    //[Route("/[controller]")]
    public class UsersController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // [HttpPost]
        //[HttpGet]
        [Route("/Users/Hugo")]
        //[Route("/Users/Enrique/{data}")]
        //[Route("/[controller]/[action]/{data}")]
        //[HttpGet("/[controller]/[action]/{data}")]
        //[HttpGet("/[controller]/[action]/{data:int}")]
        [HttpGet("/[controller]/[action]/{data:double}")]
        //public IActionResult Index(string data, int age)
        public IActionResult Index(double data)
        {
            //ViewData["id"] = data + " " + age;
            return View("Index", data);
        }

    } 
}