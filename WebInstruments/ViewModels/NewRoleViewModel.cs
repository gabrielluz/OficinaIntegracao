using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewRoleViewModel
    {
        public Role Role { get; set; }
        public List<Role> Roles { get; set; }
    }
}