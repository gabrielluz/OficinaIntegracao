using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewInstrumentTypeViewModel
    {
        public List<InstrumentType> InstrumentTypes { get; set; }
        public InstrumentType InstrumentType { get; set; }
    }
}