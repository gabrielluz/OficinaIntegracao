using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class MeasurementUnitMap : EntityTypeConfiguration<MeasurementUnit>
    {
        public MeasurementUnitMap()
        {
            this.HasKey(m => m.Id);

            this.ToTable("MeasurementUnit");

            this.Property(m => m.Id);
            this.Property(m => m.Name).HasMaxLength(50);
            this.Property(m => m.Acronym).HasMaxLength(10);
        }
    }
}