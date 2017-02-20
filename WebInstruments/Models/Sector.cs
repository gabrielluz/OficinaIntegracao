using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WebInstruments.Models
{
    public class Sector
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }
        
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        public Sector()
        {
            Users = new List<User>();
        }
    }
}