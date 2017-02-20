using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            this.HasKey(s => s.Id);

            this.ToTable("State");

            this.Property(s => s.Id).IsRequired();
            this.Property(s => s.Name).HasMaxLength(50).IsRequired();
            this.Property(s => s.Acronym).HasMaxLength(10).IsRequired();
        }
    }
}