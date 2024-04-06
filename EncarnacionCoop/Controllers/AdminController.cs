using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EncarnacionCoop.Entities;
using EncarnacionCoop.Models;

namespace EncarnacionCoop.Controllers
{

    public class AdminController : Controller
    {
        private readonly MydatabaseContext _context;

        public AdminController(MydatabaseContext user)
        {
            _context = user;
        }

        public IActionResult Index()
        {
            var usersWithUserTypes = _context.ClientInfos
            .Join(_context.UserTypes,
              clientInfo => clientInfo.UserType,
              userType => userType.Id,
              (clientInfo, userType) => new ClientInfoViewModel
              {
                  Id = clientInfo.Id,
                  UserType = userType.Name, // Assuming UserType is string in ClientInfoViewModel
                  FirstName = clientInfo.FirstName,
                  MiddleName = clientInfo.MiddleName,
                  LastName = clientInfo.LastName,
                  Address = clientInfo.Address,
                  ZipCode = clientInfo.ZipCode,
                  Birthday = clientInfo.Birthday,
                  Age = clientInfo.Age,
                  NameOfFather = clientInfo.NameOfFather,
                  NameOfMother = clientInfo.NameOfMother,
                  CivilStatus = clientInfo.CivilStatus,
                  Religion = clientInfo.Religion,
                  Occupatioin = clientInfo.Occupatioin
              })
        .ToList();

            return View(usersWithUserTypes);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var UserType = _context.UserTypes.ToList();
            ViewData["UserType"] = UserType;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientInfoViewModel clientinfo)
        {

            if (!ModelState.IsValid)
                return View(clientinfo);
            int userType;
            if (!int.TryParse(clientinfo.UserType, out userType))
            {
                return View("Error");
            }
            ClientInfo c = new ClientInfo
            {
                Id = clientinfo.Id,
                UserType = userType,
                FirstName = clientinfo.FirstName,
                MiddleName = clientinfo.MiddleName,
                LastName = clientinfo.LastName,
                Address = clientinfo.Address,
                ZipCode = clientinfo.ZipCode,
                Birthday = clientinfo.Birthday,
                Age = clientinfo.Age,
                NameOfFather = clientinfo.NameOfFather,
                NameOfMother = clientinfo.NameOfMother,
                CivilStatus = clientinfo.CivilStatus,
                Religion = clientinfo.Religion,
                Occupatioin = clientinfo.Occupatioin
            };
            _context.ClientInfos.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult View(int id)
        {

            var clientViewModel = _context.ClientInfos
         .Where(q => q.Id == id)
         .Join(_context.UserTypes,
               clientInfo => clientInfo.UserType,
               userType => userType.Id,
               (clientInfo, userType) => new ClientInfoViewModel
               {
                   Id = clientInfo.Id,
                   UserType = userType.Name,
                   FirstName = clientInfo.FirstName,
                   MiddleName = clientInfo.MiddleName,
                   LastName = clientInfo.LastName,
                   Address = clientInfo.Address,
                   ZipCode = clientInfo.ZipCode,
                   Birthday = clientInfo.Birthday,
                   Age = clientInfo.Age,
                   NameOfFather = clientInfo.NameOfFather,
                   NameOfMother = clientInfo.NameOfMother,
                   CivilStatus = clientInfo.CivilStatus,
                   Religion = clientInfo.Religion,
                   Occupatioin = clientInfo.Occupatioin
               })
         .FirstOrDefault();

            if (clientViewModel == null)
            {
                return NotFound();
            }
            return View(clientViewModel);
            // var clientEntity = new EncarnacionCoop.Entities.ClientInfo
            // {
            //     Id = clientViewModel.Id,
            //      UserType = userType.Name,
            //     FirstName = clientViewModel.FirstName,
            //     MiddleName = clientViewModel.MiddleName,
            //     LastName = clientViewModel.LastName,
            //     Address = clientViewModel.Address,
            //     ZipCode = clientViewModel.ZipCode,
            //     Birthday = clientViewModel.Birthday,
            //     Age = clientViewModel.Age,
            //     NameOfFather = clientViewModel.NameOfFather,
            //     NameOfMother = clientViewModel.NameOfMother,
            //     CivilStatus = clientViewModel.CivilStatus,
            //     Religion = clientViewModel.Religion,
            //     Occupatioin = clientViewModel.Occupatioin
            // };

            // return View(clientEntity); // Pass the converted entity to the view
        }


        [HttpGet]
        public ActionResult Update(int id)
        {

            var UserType = _context.UserTypes.ToList();
            ViewData["UserType"] = UserType;
            var clientViewModel = _context.ClientInfos
        .Where(q => q.Id == id)
        .Join(_context.UserTypes,
              clientInfo => clientInfo.UserType,
              userType => userType.Id,
              (clientInfo, userType) => new ClientInfoViewModel
              {
                  Id = clientInfo.Id,
                  UserType = userType.Name,
                  FirstName = clientInfo.FirstName,
                  MiddleName = clientInfo.MiddleName,
                  LastName = clientInfo.LastName,
                  Address = clientInfo.Address,
                  ZipCode = clientInfo.ZipCode,
                  Birthday = clientInfo.Birthday,
                  Age = clientInfo.Age,
                  NameOfFather = clientInfo.NameOfFather,
                  NameOfMother = clientInfo.NameOfMother,
                  CivilStatus = clientInfo.CivilStatus,
                  Religion = clientInfo.Religion,
                  Occupatioin = clientInfo.Occupatioin
              })
                .FirstOrDefault();

            if (clientViewModel == null)
            {
                return NotFound();
            }
            return View(clientViewModel);

            // var clientEntity = new EncarnacionCoop.Entities.ClientInfo
            // {
            //     Id = clientViewModel.Id,
            //     UserType = clientViewModel.UserType,
            //     FirstName = clientViewModel.FirstName,
            //     MiddleName = clientViewModel.MiddleName,
            //     LastName = clientViewModel.LastName,
            //     Address = clientViewModel.Address,
            //     ZipCode = clientViewModel.ZipCode,
            //     Birthday = clientViewModel.Birthday,
            //     Age = clientViewModel.Age,
            //     NameOfFather = clientViewModel.NameOfFather,
            //     NameOfMother = clientViewModel.NameOfMother,
            //     CivilStatus = clientViewModel.CivilStatus,
            //     Religion = clientViewModel.Religion,
            //     Occupatioin = clientViewModel.Occupatioin
            // };

            // return View(clientEntity); // Pass the converted entity to the view
        }

        [HttpPost]
        public ActionResult Update(ClientInfoViewModel clientupdate)
        {
            if (!ModelState.IsValid)
            {
                return View(clientupdate);
            }

            // Retrieve the corresponding UserType ID from the UserTypes table
            var userType = _context.UserTypes
                                  .FirstOrDefault(u => u.Name == clientupdate.UserType);

            if (userType == null)
            {
                return View("Error");
            }

            var existingClient = _context.ClientInfos.Find(clientupdate.Id);

            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.UserType = userType.Id; // Assign the retrieved UserType ID
            existingClient.FirstName = clientupdate.FirstName;
            existingClient.MiddleName = clientupdate.MiddleName;
            existingClient.LastName = clientupdate.LastName;
            existingClient.Address = clientupdate.Address;
            existingClient.ZipCode = clientupdate.ZipCode;
            existingClient.Birthday = clientupdate.Birthday;
            existingClient.Age = clientupdate.Age;
            existingClient.NameOfFather = clientupdate.NameOfFather;
            existingClient.NameOfMother = clientupdate.NameOfMother;
            existingClient.CivilStatus = clientupdate.CivilStatus;
            existingClient.Religion = clientupdate.Religion;
            existingClient.Occupatioin = clientupdate.Occupatioin;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var clientInfo = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(clientInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}