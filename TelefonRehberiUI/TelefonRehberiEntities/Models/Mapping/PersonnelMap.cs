using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TelefonRehberiEntities.Models.Mapping
{
    public class PersonnelMap : EntityTypeConfiguration<Personnel>
    {
        public PersonnelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Personnel");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");
            
            // Relationships
            this.HasOptional(t => t.Department)
                .WithMany(t => t.Personnels)
                .HasForeignKey(d => d.DepartmentId);
            this.HasOptional(t => t.Personnel2)
                .WithMany(t => t.Personnel1)
                .HasForeignKey(d => d.ManagerId);

        }
    }
}
