using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebInstruments.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasAccess { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}