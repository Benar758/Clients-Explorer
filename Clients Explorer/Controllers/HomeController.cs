using Clients_Explorer.DB;
using Clients_Explorer.Models;
using Clients_Explorer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private ApplicationContext _context { get; set; }

        public IActionResult Index()
        {
            var clients = _context.Clients.Include(c => c.Founders).ToList();

            return View(clients);
        }

        public IActionResult EditClient()
        {

            return View();
        }
    }
}
