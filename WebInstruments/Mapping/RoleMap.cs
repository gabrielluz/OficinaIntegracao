using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(r => r.Id);

            this.ToTable("Role");

            this.Property(r => r.Id);
            this.Property(r => r.Name).HasMaxLength(50);
            this.Property(r => r.HasAccess);
        }
    }
}