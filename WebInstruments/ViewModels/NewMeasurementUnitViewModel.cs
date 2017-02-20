using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewMeasurementUnitViewModel
    {
        public List<MeasurementUnit> MeasurementUnits { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
    }
}