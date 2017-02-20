using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.HasKey(c => c.Id);

            this.ToTable("City");

            this.Property(s => s.Id)
                .IsRequired();

            this.Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(s => s.IdState);

            this.HasRequired(s => s.State)
                .WithMany(st => st.Cities)
                .HasForeignKey(s => s.IdState).WillCascadeOnDelete(false);
        }
    }
}