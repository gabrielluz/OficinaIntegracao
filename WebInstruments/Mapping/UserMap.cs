using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebInstruments.Models;

namespace WebInstruments.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap UserMap1 { get; set; }

        public UserMap()
        {
            this.HasKey(u => u.Id);

            this.ToTable("User");

            this.Property(u => u.Id);
            this.Property(u => u.IdRole);
            this.Property(u => u.IdSector);
            this.Property(u => u.IdAddress);
            this.Property(u => u.Cpf);
            this.Property(u => u.Email);
            this.Property(u => u.Name);
            this.Property(u => u.Password);

            this.HasRequired(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.IdRole);

            this.HasRequired(u => u.Sector)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.IdSector);

            this.HasRequired(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.IdAddress).WillCascadeOnDelete(false);
        }
    }
}