using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class InstrumentTypeMap : EntityTypeConfiguration<InstrumentType>
    {
        public InstrumentTypeMap()
        {
            this.HasKey(it => it.Id);

            this.ToTable("InstrumentType");

            this.Property(it => it.Id);
            this.Property(it => it.Name).HasMaxLength(50);
        }
    }
}