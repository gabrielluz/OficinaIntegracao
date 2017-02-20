using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int IdAddress { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }

        public virtual Address AddressSup { get; set; }

        [JsonIgnore]
        public virtual ICollection<Instrument> Instruments { get; set; }

        public Supplier()
        {
            Instruments = new List<Instrument>();
        }
    }
}