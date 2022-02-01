using Clients_Explorer.DB;
using Clients_Explorer.ViewModels;
using Clients_Explorer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.Controllers
{
    public class ClientController : Controller
    {

        public ClientController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private ApplicationContext _context { get; set; }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewClient(ClientsViewModel model)
        {
            if (!ModelState.IsValid && model.Client.Type == "Юр. лицо")
            {               
                return View("ValidationError");
            }

            if (!ModelState.IsValid && model.Client.Type == "ИП")
            {
                if (string.IsNullOrEmpty(model.Client.Name)) return View("ValidationError");
                if (string.IsNullOrEmpty(model.Client.TaxesPayerNumber)) return View("ValidationError");

                bool isNumber = false;

                try
                {
                    foreach (var e in model.Client.TaxesPayerNumber)
                    {
                        try
                        {
                            int.Parse(e.ToString());
                            isNumber = true;
                        }
                        catch
                        {
                            isNumber = false;
                            break;
                        }
                    }
                }
                catch
                {
                    return View("ValidationError");
                }

                if (!isNumber) return View("ValidationError");
            }

            if(ModelState.IsValid)
            {
                bool isNumber = false;

                try
                {
                    foreach (var e in model.Client.TaxesPayerNumber)
                    {
                        try
                        {
                            int.Parse(e.ToString());
                            isNumber = true;
                        }
                        catch
                        {
                            isNumber = false;
                            break;
                        }
                    }

                    foreach (var e in model.Founder.TaxesPayerNumber)
                    {
                        try
                        {
                            int.Parse(e.ToString());
                            isNumber = true;
                        }
                        catch
                        {
                            isNumber = false;
                            break;
                        }
                    }
                }
                catch
                {
                    View("ValidationError");
                }

                if (!isNumber) return View("ValidationError");
            }

            Client client = model.Client;
            Founder founder;

            if (client.Type == "Юр. лицо")
            {
                founder = model.Founder;

                client.Founders.Add(founder);
                _context.Founders.Add(founder);
            }

            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
