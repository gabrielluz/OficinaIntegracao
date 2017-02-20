using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebInstruments.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdInstrument { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        public virtual User User { get; set; }
        public virtual Instrument Instrument { get; set; }

        public Loan()
        {

        }
    }
}