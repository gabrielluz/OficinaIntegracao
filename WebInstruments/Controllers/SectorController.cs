using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInstruments.Filters;
using WebInstruments.Models;
using WebInstruments.ViewModels;

namespace WebInstruments.Controllers
{
    [AuthorizationFilter]
    public class SectorController : Controller
    {
        private ApplicationDbContext _context;

        public SectorController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult SectorList()
        {
            var viewModel = new NewSectorViewModel()
            {
                Sectors = _context.Sectors.ToList()
            };

            return View(viewModel);
        }


        public ActionResult Remove(long id)
        {
            var sectorToDelete = _context.Sectors.SingleOrDefault(s => s.Id == id);

            if (sectorToDelete == null)
                return HttpNotFound();

            _context.Sectors.Remove(sectorToDelete);
            _context.SaveChanges();

            return RedirectToAction("SectorList", "Sector");
        }

        public ActionResult Save(Sector sector)
        {
            if (Convert.ToInt32(sector.Id) == 0)
            {
                _context.Sectors.Add(sector);
            }
            else
            {
                var sectorToModify = _context
                    .Sectors
                    .SingleOrDefault(i => i.Id == sector.Id);

                if (sectorToModify == null)
                    return HttpNotFound();

                sectorToModify.Id = sector.Id;
                sectorToModify.Name = sector.Name;
                sectorToModify.Description = sector.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("SectorList", "Sector");
        }
        [HttpPost]
        public ContentResult GetData(int id)
        {
            var sector = _context.Sectors.SingleOrDefault(sc => sc.Id == id);

            return Content(JsonConvert.SerializeObject(sector));
        }
    }
}