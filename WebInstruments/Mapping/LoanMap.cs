using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class LoanMap : EntityTypeConfiguration<Loan>
    {
        public LoanMap()
        {
            this.HasKey(l => l.Id);

            this.ToTable("Loan");

            this.Property(l => l.Id);
            this.Property(l => l.IdUser);
            this.Property(l => l.StartDate);
            this.Property(l => l.FinishDate);

            this.HasRequired(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.IdUser);
        }
    }
}