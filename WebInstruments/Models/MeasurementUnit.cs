using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class MeasurementUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        [JsonIgnore]
        public virtual ICollection<Instrument> Instruments { get; set; }

        public MeasurementUnit()
        {
            Instruments = new List<Instrument>();
        }
    }
}