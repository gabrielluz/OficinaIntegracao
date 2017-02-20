using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewSupplierViewModel
    {
        public Address Address { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<State> States { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Models.Address> Addresses { get; set; }
        public Supplier Supplier { get; set; }

    }
}