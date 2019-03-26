using System.Data.Entity;
using TelefonRehberiEntities.Models;
using TelefonRehberiEntities.Models.Mapping;

namespace TelefonRehberi.DataAccessLayer.EntityFramework
{
    public partial class TelefonRehberiContext : DbContext
    {
        static TelefonRehberiContext()
        {
            Database.SetInitializer<TelefonRehberiContext>(null);
        }

        public TelefonRehberiContext()
            : base("Name=TelefonRehberiContext")
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new PersonnelMap());
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
