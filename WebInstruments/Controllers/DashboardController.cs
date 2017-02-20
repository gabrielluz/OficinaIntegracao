using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInstruments.Models;
using WebInstruments.ViewModels;

namespace WebInstruments.Controllers
{
    public class Classe
    {
        public String nome { get; set; }
        public int quantidade { get; set; }
    }
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var viewModel = new NewDashboardViewModel()
            {
                Instruments = _context.Instruments.OrderByDescending(i => i.Id).Take(5).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ContentResult GetInstrumentTypes()
        {
            //SELECT top 5 c.CategoryName, count(p.CategoryID) from products p inner join categories c on (p.CategoryID = c.CategoryId) group by c.CategoryName order by count(p.CategoryID) desc;
            //var instrument = _context.Database.SqlQuery<List<object>>("SELECT TOP 5 it.Name as tipo, COUNT(i.IdInstrumentType) as qtd " +
            //                                                    "FROM Instrument i INNER JOIN InstrumentType it ON (i.IdInstrumentType = it.Id) GROUP BY it.Name ORDER BY COUNT(i.IdInstrumentType)").ToList();
            _context.Database.Connection.Open();
            var c = new List<List<Object>>();
            c.Add(new List<object>(new object[] {"tipo","quantidade"}));
            var query = "SELECT TOP 5 it.Name as tipo, COUNT(i.IdInstrumentType) as qtd FROM Instrument i INNER JOIN InstrumentType it ON (i.IdInstrumentType = it.Id) GROUP BY it.Name ORDER BY COUNT(i.IdInstrumentType)";
            using (SqlCommand command = new SqlCommand(query, _context.Database.Connection as SqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //dic.Add(reader.GetString(0),reader.GetInt32(1));
                        c.Add(new List<Object>(new object[] {reader.GetString(0), reader.GetInt32(1)}));
                    }
                }
            }
            _context.Database.Connection.Close();
            return Content(JsonConvert.SerializeObject(c));
        }
        
    }


}
