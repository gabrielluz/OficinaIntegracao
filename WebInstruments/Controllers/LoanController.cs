using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInstruments.Filters;
using WebInstruments.Models;
using WebInstruments.ViewModels;

namespace WebInstruments.Controllers
{
    [AuthorizationFilter]
    public class LoanController : Controller
    {
        private ApplicationDbContext _context;

        public LoanController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult LoanList()
        {
            var viewModel = new NewLoanViewModel()
            {
                Loans = _context.Loans
                    .Include("Instrument")
                    .ToList(),
                NewLoan = new Loan()
                {
                    StartDate = DateTime.Now,
                    FinishDate = DateTime.Now.AddDays(7)
                },
                Instruments = _context.Instruments.ToList(),
                Users = _context.UsersS.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Save(NewLoanViewModel loanViewModel)
        {
            var loan = loanViewModel.NewLoan;
            var user = (User)HttpContext.Session["User"];

            //loan.IdUser = user.Id;
            
            if (loan.Id == 0)
                AddLoan(loan);
            else
                UpdateLoan(loan);
            
            return RedirectToAction("LoanList");
        }

        public ActionResult Remove(int id)
        {
            var loanToRemove = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loanToRemove == null)
                return HttpNotFound();

            _context.Loans.Remove(loanToRemove);
            _context.SaveChanges();

            return RedirectToAction("LoanList");
        }

        private void AddLoan(Loan loan)
        {
            loan.StartDate = DateTime.Now;
            loan.FinishDate = DateTime.Now.AddDays(7);
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }
        
        private void UpdateLoan(Loan loan)
        {
            var loanToUpdate = _context.Loans.SingleOrDefault(l => l.Id == loan.Id);

            loanToUpdate.StartDate = loan.StartDate;
            loanToUpdate.FinishDate = loan.FinishDate;
            loanToUpdate.IdInstrument = loan.IdInstrument;

            _context.SaveChanges();
        }
    }
}