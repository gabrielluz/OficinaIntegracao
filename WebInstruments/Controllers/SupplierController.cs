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
    public class SupplierController : Controller
    {
        private ApplicationDbContext _context;

        public SupplierController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult SupplierList()
        {
            var viewModel = new NewSupplierViewModel()
            {
                Suppliers = _context.Suppliers.ToList(),
                States = _context.States.ToList(),
                Addresses = _context.Addresses.ToList(),
                Cities = new List<City>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {

            _context.Suppliers.Remove(_context.Suppliers.SingleOrDefault(s => s.Id == id));
            _context.SaveChanges();

            return RedirectToAction("SupplierList", "Supplier");
        }


        [HttpPost]
        public ActionResult Save(NewSupplierViewModel model)
        {
            var address = model.Address;
            address.Cep = address.Cep.Replace("-", "").Replace(".", "");

            var supplier = model.Supplier;
            supplier.CNPJ = supplier.CNPJ.Replace(".", "").Replace("/", "").Replace(".", "").Replace("-", "");


            if (model.Address.Id == 0)
            {
                _context.Addresses.Add(address);
            }
            else
            {
                var addressToModify = _context
                    .Addresses
                    .SingleOrDefault(a => a.Id == address.Id);

                if (addressToModify == null)
                    return HttpNotFound();

                addressToModify.Cep = address.Cep;
                addressToModify.IdCity = address.IdCity;
                addressToModify.IdState = address.IdState;
                addressToModify.Complement = address.Complement;
                addressToModify.Number = address.Number;
                addressToModify.Street = address.Street;
            }
            _context.SaveChanges();

            if (supplier.Id == 0)
            {
                supplier.IdAddress = address.Id;
                _context.Suppliers.Add(supplier);
            }
            else
            {
                var supplierToModify = _context
                    .Suppliers
                    .SingleOrDefault(s => s.Id == supplier.Id);

                supplierToModify.IdAddress = address.Id;
                supplierToModify.Name = supplier.Name;
                supplierToModify.CNPJ = supplier.Name;

            }
            _context.SaveChanges();

            return RedirectToAction("SupplierList", "Supplier");
        }
        
        [HttpPost]
        public ContentResult GetCities(int state)
        {
            var data = _context.Cities.Where(c => c.IdState == state);
            return Content(JsonConvert.SerializeObject(data));
        }

        [HttpPost]
        public ContentResult GetData(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(i => i.Id == id);
            return Content(JsonConvert.SerializeObject(supplier));
        }
    }
}