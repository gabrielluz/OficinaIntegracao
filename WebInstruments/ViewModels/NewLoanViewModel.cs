using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.ViewModels
{
    public class NewLoanViewModel
    {
        //public NewLoanViewModel()
        //{
        //    Loans = new List<Loan>();
        //    Instruments = new List<Instrument>();
        //    Users = new List<User>();
        //}

        public Loan NewLoan { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Instrument> Instruments { get; set; }
        public ICollection<User> Users { get; set; }
    }
}