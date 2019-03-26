using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;


namespace TelefonRehberiEntities.Models.Mapping
{
   public class AdminMap : EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
              .IsRequired()
              .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Admin");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}
