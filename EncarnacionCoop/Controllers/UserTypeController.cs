using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EncarnacionCoop.Entities;
using EncarnacionCoop.Models;
using Microsoft.Data.Sql;

namespace EncarnacionCoop.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly MydatabaseContext _context;

        public UserTypeController(MydatabaseContext usertype)
        {
            _context = usertype;
        }

        public IActionResult Index()
        {
             var user = _context.UserTypes.ToList();
            return View(user);
        }
         [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserTypeViewModel asa)
        {
    
           if (!ModelState.IsValid)
                return View(asa);
            UserType c = new UserType
           {
                Id = asa.Id,
                Name = asa.Name
           };
             _context.UserTypes.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

          public ActionResult Update(int id)
        {
            var UserTypeViewModel = _context.UserTypes
                .Where(q => q.Id == id)
                .Select(clientupdate => new UserTypeViewModel
                {
                    Id = clientupdate.Id,
                    Name = clientupdate.Name
                })
                .FirstOrDefault();

            if (UserTypeViewModel == null)
            {
                return NotFound();
            }

            var clientEntity = new EncarnacionCoop.Entities.UserType
            {
                Id = UserTypeViewModel.Id,
                Name = UserTypeViewModel.Name
                
            };

            return View(clientEntity); // Pass the converted entity to the view
        }

        [HttpPost]
        public ActionResult Update(UserTypeViewModel clientupdate)
        {
            if (!ModelState.IsValid)
            {
                return View(clientupdate);
            }

            var existingClient = _context.UserTypes.Find(clientupdate.Id);

            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Name = clientupdate.Name;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
            var clientInfo = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            _context.UserTypes.Remove(clientInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}