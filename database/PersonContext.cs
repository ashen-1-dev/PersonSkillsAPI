using Microsoft.EntityFrameworkCore;
using test_case.Models;

namespace test_case.database
{
    public class PersonContext : DbContext
    {
        public PersonContext()
            : base()
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonSkill> PersonSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PersonDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSkill>().HasKey(ps => new {ps.PersonId, ps.SkillId});
        }
    }
}