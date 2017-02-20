using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebInstruments.Models;
using WebInstruments.ViewModels;
using WebInstruments.Filters;

namespace WebInstruments.Controllers
{
    [AuthorizationFilter]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        [AuthorizationFilter]
        public ViewResult UserList()
        {
            var cidadesParana = _context.Cities.Where(x => x.IdState == 1).ToList();
            var viewModel = new NewUserViewModel()
            {
                Users = _context.UsersS.ToList(),
                Roles = _context.RolesS.ToList(),
                Sectors = _context.Sectors.ToList(),
                States = _context.States.ToList(),
                Cities = cidadesParana,
                Addresses = _context.Addresses.Include(e => e.State).Include(x => x.City).ToList()
            };

            return View(viewModel);
        }

        public ActionResult Save(NewUserViewModel viewModel)
        {
            var address = viewModel.Address;
            var user = viewModel.User;

            _context.Addresses.Add(address);
            _context.SaveChanges();

            user.IdAddress = address.Id;
            _context.UsersS.Add(user);
            _context.SaveChanges();

            return RedirectToAction("UserList");
        }

        private void AddUser(User user)
        {
            _context.Addresses.Add(user.Address);
            user.IdAddress = user.Address.Id;
            _context.UsersS.Add(user);
            _context.SaveChanges();
        }

        private void UpdateUser(User user)
        {
            var userToUpdate = _context.UsersS.SingleOrDefault(u => u.Id == user.Id);

            userToUpdate.Cpf = user.Cpf;
            userToUpdate.Email = user.Email;
            userToUpdate.Name = user.Name;
            userToUpdate.Password = user.Password;
            userToUpdate.IdAddress = user.IdAddress;
            userToUpdate.IdRole = user.IdRole;
            userToUpdate.IdSector = user.IdSector;

            _context.SaveChanges();
        }

        public ActionResult Remove(int id)
        {
            _context.UsersS.Remove(_context.UsersS.SingleOrDefault(u => u.Id == id));
            _context.SaveChanges();

            return RedirectToAction("UserList");
        }

        [HttpPost]
        public ContentResult GetData(int id)
        {
            var user = _context.UsersS.SingleOrDefault(u => u.Id == id);
            return Content(JsonConvert.SerializeObject(user));
        }
    }
}