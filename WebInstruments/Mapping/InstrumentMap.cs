using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class InstrumentMap : EntityTypeConfiguration<Instrument>
    {
        public InstrumentMap()
        {
            this.HasKey(i => i.Id);

            this.ToTable("Instrument");

            this.Property(i => i.Id);
            this.Property(i => i.IdInstrumentType);
            this.Property(i => i.IdMeasurementUnit);
            this.Property(i => i.IdSupplier);
            this.Property(i => i.IdUser);
            this.Property(i => i.Code).IsRequired();
            this.Property(i => i.MaximumValue);
            this.Property(i => i.MinimumValue);
            this.Property(i => i.RegisterDate);

            this.HasRequired(i => i.Supplier)
                .WithMany(s => s.Instruments)
                .HasForeignKey(i => i.IdSupplier);

            this.HasRequired(i => i.User)
                .WithMany(u => u.Instruments)
                .HasForeignKey(i => i.IdUser);

            this.HasRequired(i => i.MeasurementUnit)
                .WithMany(m => m.Instruments)
                .HasForeignKey(i => i.IdMeasurementUnit);

            this.HasRequired(i => i.InstrumentType)
                .WithMany(it => it.Instruments)
                .HasForeignKey(i => i.IdInstrumentType);

        }
    }
}