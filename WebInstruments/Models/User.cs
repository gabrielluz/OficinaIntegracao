using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WebInstruments.Models
{
    public class User
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public int IdSector { get; set; }
        public int IdAddress { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        [Required, DisplayName("E-mail")]
        public string Email { get; set; }

        [Required, DisplayName("Senha")]
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual Address Address { get; set; }

        [JsonIgnore]
        public virtual ICollection<Loan> Loans { get; set; }
        [JsonIgnore]
        public virtual ICollection<Instrument> Instruments { get; set; }

        public User()
        {
            Loans = new List<Loan>();
            Instruments = new List<Instrument>();
        }
    }
}