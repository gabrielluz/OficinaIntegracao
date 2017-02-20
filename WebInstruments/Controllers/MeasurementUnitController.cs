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
    public class MeasurementUnitController : Controller
    {
        private ApplicationDbContext _context;

        public MeasurementUnitController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult MeasurementUnitList()
        {
            var viewModel = new NewMeasurementUnitViewModel()
            {
                MeasurementUnits = _context.MeasurementUnits.ToList(),
            };

            return View(viewModel);
        }
        
        public ActionResult Save(MeasurementUnit measurementUnit)
        {
            if (Convert.ToInt32(measurementUnit.Id) == 0)
            {
                _context.MeasurementUnits.Add(measurementUnit);
            }
            else
            {
                var measurementUnitToModify =_context.MeasurementUnits.SingleOrDefault(mu => mu.Id == measurementUnit.Id);
                if (measurementUnitToModify == null)
                    return HttpNotFound();

                measurementUnitToModify.Name = measurementUnit.Name;
                measurementUnitToModify.Acronym = measurementUnit.Acronym;
            }
            _context.SaveChanges();

            return RedirectToAction("MeasurementUnitList", "MeasurementUnit");
        }
        
        public ActionResult Remove(int id)
        {
            var measurementUnitToDelete = _context.MeasurementUnits.SingleOrDefault(x => x.Id == id);
            _context.MeasurementUnits.Remove(measurementUnitToDelete);
            _context.SaveChanges();


            return RedirectToAction("MeasurementUnitList", "MeasurementUnit");
        }

        [HttpPost]
        public ContentResult getData(int id)
        {
            var measurementUnit = _context.MeasurementUnits.SingleOrDefault(mu => mu.Id == id);
            return Content(JsonConvert.SerializeObject(measurementUnit));
        }
    }
}