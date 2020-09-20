using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DbEntities
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Hobbies> Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobbies>()
                .HasData(
                new Hobbies()
                { Id = 1, HobbyName = "Playing Crikt" },
                new Hobbies()
                { Id = 2, HobbyName = "Cooking" },
                new Hobbies()
                { Id = 3, HobbyName = "Dancing" });

            modelBuilder.Entity<Role>()
                .HasData(
                new Role()
                { Id = 1, RoleName = "Business Analyst" },
                new Role()
                { Id = 2, RoleName = "Project Manager" },
                new Role()
                { Id = 3, RoleName = "Software Developer" },
                new Role()
                { Id = 4, RoleName = "Web Designer" }
                );

            modelBuilder.Entity<Skills>()
                .HasData(
                new Skills()
                { Id = 1, SkillsName = "HTML/CSS" },
                new Skills()
                { Id = 2, SkillsName = "Dot Net" },
                new Skills()
                { Id = 3, SkillsName = "Andriod" },
                new Skills()
                { Id = 4, SkillsName = "iOS" },
                new Skills()
                { Id = 5, SkillsName = "Java" },
                new Skills()
                { Id = 6, SkillsName = "SQL" },
                new Skills()
                { Id = 7, SkillsName = "AI" },
                new Skills()
                { Id = 8, SkillsName = "ML" },
                new Skills()
                { Id = 9, SkillsName = "XML" },
                new Skills()
                { Id = 10, SkillsName = "Python" },
                new Skills()
                { Id = 11, SkillsName = "JavaScript/jQuery" }
                );

            base.OnModelCreating(modelBuilder);
        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
