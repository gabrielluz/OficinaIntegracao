using WebInstruments.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebInstruments.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.HasKey(x => x.Id);

            this.ToTable("Address");

            this.Property(a => a.Id);
            this.Property(a => a.Cep);
            this.Property(a => a.Complement);
            this.Property(a => a.Neighborhood);
            this.Property(a => a.Number);


            this.HasRequired(a => a.State)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.IdState);

            this.HasRequired(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.IdCity);
        }
    }
}