using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebInstruments.Models
{
    public class Instrument
    {
        
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMeasurementUnit { get; set; }
        public int IdSupplier { get; set; }
        public int IdInstrumentType { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual User User { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual InstrumentType InstrumentType { get; set; }

        public Instrument()
        {

        }
    }
}