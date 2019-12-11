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
        //[Route("/Users/Hugo")]
        //[Route("/Users/Enrique/{data}")]
        //[Route("/[controller]/[action]/{data}")]
        //[HttpGet("/[controller]/[action]/{data}")]
        //[HttpGet("/[controller]/[action]/{data:int}")]
        //[HttpGet("/[controller]/[action]/{data:double}")]
        //public IActionResult Index(string data, int age)
        //public IActionResult Index(double data)
        //{
        //    //ViewData["id"] = data + " " + age;
        //    return View("Index", data);
        //}


        // Creando URLs personalizadas
        public IActionResult Index(double data)
        {
            //var url = Url.Action("Method", "Users", new { age = 25, name = "Hugo" });
            //var url = Url.Action("Method", "Users");
            //return View("Index", data);
            //return Content(url);
            var url = Url.RouteUrl("Cristina", new { age = 28, name = "Hugo" });
            return Redirect(url);
        }

        [HttpGet("/[controller]/[action]", Name = "Cristina")]
        public IActionResult Method(int age, String name)
        {
            var data = $"Nombre: {name} y Edad: {age}";
            return View("Index", data);
        }
        
        //public IActionResult Method()
        //{
        //    return View();
        //} 

    } 
}