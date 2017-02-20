using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set; }
        public State()
        {
            Addresses = new List<Address>();
        }
    }
}