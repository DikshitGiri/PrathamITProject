using Dot.Data;
using Dot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;
using System.Net;

namespace Dot.Controllers
{
    public class HomeController : Controller

    {
        private ApplicationDbContext Context { get; set; }
        public HomeController(ApplicationDbContext context)
        {
            this.Context = context;
        }
       
        

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Entry()
        {
            var category = Context.Itemlist.ToList();
            ViewBag.data = category;
            return View();
           
        }
        [HttpPost]
        public IActionResult Entry(EntryPoint ep)
        {
            Context.Inventories.Add(ep);
            Context.SaveChanges();
            return View(ep);

        }
        public IActionResult Travel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Travel(TravelTicket tk) {
           
            //var Ticket = new TravelTicket()
            //{
            // Id=tk.Id,
            // Booked= tk.Booked,
            // Category= tk.Category,
            // PassangerName= tk.PassangerName,   
            // Route= tk.Route,
            //};

            this.Context.Tickets.Add(tk);
            this.Context.SaveChanges();
            

            return RedirectToAction("Result");
        
        }

        public IActionResult Result()
        {
            return View(Context.Tickets.ToList());
        }
        public IActionResult Edit(int id)
        {
            return View(Context.Tickets.Find(id));


        }
        [HttpPost]
        public IActionResult Update(TravelTicket t)

        {   
            Context.Tickets.Update(t);
            Context.SaveChanges();
            return RedirectToAction("Result");
           
        }
        public IActionResult Details(int id)

        {
            
            return View(Context.Tickets.Find(id));

        }
        public IActionResult Delete(int id)
        {
            var ToDelete = Context.Tickets.Find(id);
            Context.Tickets.Remove(ToDelete);
            Context.SaveChanges();
            return RedirectToAction("Result");
          
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}