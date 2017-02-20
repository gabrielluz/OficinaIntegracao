using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            this.HasKey(s => s.Id);

            this.ToTable("Supplier");

            this.Property(s => s.Id)
                .IsRequired();

            this.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(s => s.CNPJ)
                .HasMaxLength(14)
                .IsRequired();

            this.HasRequired(s => s.AddressSup)
                .WithMany(a => a.Suppliers)
                .HasForeignKey(s => s.IdAddress);
        }
    }
}