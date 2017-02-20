using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInstruments.Dto
{
    public class MeasurementUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        public string FullName
        {
            get { return string.Format("? - ?", Name, Acronym); }
        }
    }
}