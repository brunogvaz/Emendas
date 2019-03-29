using Emendas.Data;
using Emendas.Web.Services;
using Emendas.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emendas.Web.Controllers
{
    public class AppController:Controller
    {
        private readonly IMailService _mailService;
        private readonly IEmendasRepository _repository;

        public AppController(IMailService mailService,IEmendasRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            
            //ViewBag.Title = "Contact";  FICA agora na view!
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(model.Email, model.Subject, model.Msg);
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }
            else
            {

            }
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }

        public IActionResult Parlamentar()
        {
            ViewBag.Title = "Empenhos";
            var result = _repository.GetParlamentars();
            return View(result);
        }
    }
}
