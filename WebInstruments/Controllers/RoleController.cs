using System;
using System.Collections.Generic;
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
    public class RoleController : Controller
    {
        private ApplicationDbContext _context;

        public RoleController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult RoleList()
        {
            var viewModel = new NewRoleViewModel()
            {
                Roles = _context.RolesS.ToList(),
            };

            return View(viewModel);
        }

        public ActionResult Remove(int id)
        {
            _context.RolesS.Remove(_context.RolesS.SingleOrDefault(r => r.Id == id));
            _context.SaveChanges();

            return RedirectToAction("RoleList", "Role");
        }

        public ActionResult Save(Role role)
        {
            if (Convert.ToInt32(role.Id) == 0)
            {
                _context.RolesS.Add(role);
            }
            else
            {
                var roleToModify = _context
                    .RolesS
                    .SingleOrDefault(r => r.Id == role.Id);

                if (roleToModify == null)
                    return HttpNotFound();

                roleToModify.Name = role.Name;
                roleToModify.HasAccess = role.HasAccess;
            }

            _context.SaveChanges();

            return RedirectToAction("RoleList", "Role");
        }
        [HttpPost]
        public ContentResult GetData(int id)
        {
            var role = _context.RolesS.SingleOrDefault(r => r.Id == id);
            return Content(JsonConvert.SerializeObject(role));
        }
    }
}