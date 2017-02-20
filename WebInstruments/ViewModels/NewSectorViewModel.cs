using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewSectorViewModel
    {
        public ICollection<Sector> Sectors { get; set; }
        public Sector Sector { get; set; }
    }
}