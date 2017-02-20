using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdState { get; set; }
        public virtual State State { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}