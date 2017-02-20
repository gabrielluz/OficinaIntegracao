using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string Cep { get; set; }
        public int IdState { get; set; }
        public int IdCity { get; set; }
        public City City { get; set; }
        public virtual State State { get; set; }
        [JsonIgnore]
        public virtual ICollection<Supplier> Suppliers { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        public Address()
        {

        }
    }
}