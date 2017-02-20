using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewUserViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Sector> Sectors { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<State> States { get; set; }

        public Models.Address Address { get; set; }
        public List<Models.Address> Addresses { get; set; }

    }
}