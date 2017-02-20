using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebInstruments.Models;

namespace WebInstruments.Controllers
{
    public class CityController : Controller
    {
        private ApplicationDbContext _context;

        public CityController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public string GetCitiesByStateId(int idState)
        {
            var cities = _context
                .Cities
                .Where(x => x.IdState == idState)
                .ToList();

            var serializedCities = JsonConvert.SerializeObject(cities);

            return serializedCities;
        }
    }
}