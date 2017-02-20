using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class InstrumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] 
        public virtual ICollection<Instrument> Instruments { get; set; }

        public InstrumentType()
        {
            Instruments = new List<Instrument>();
        }
    }
}