using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class SectorMap : EntityTypeConfiguration<Sector>
    {
        public SectorMap()
        {
            this.HasKey(s => s.Id);

            this.ToTable("Sector");

            this.Property(s => s.Id);
            this.Property(s => s.Name).HasMaxLength(50);
            this.Property(s => s.Description).HasMaxLength(300);
        }
    }
}