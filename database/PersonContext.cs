using Microsoft.EntityFrameworkCore;
using test_case.Models;

namespace test_case.database
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSkill>()
                .HasKey(t => new {t.PersonId, t.SkillId});

            modelBuilder.Entity<PersonSkill>()
                .HasOne(t => t.Person)
                .WithMany(t => t.PersonSkills)
                .HasForeignKey(t => t.PersonId);

            modelBuilder.Entity<PersonSkill>()
                .HasOne(t => t.Skill)
                .WithMany(t => t.PersonSkills)
                .HasForeignKey(t => t.SkillId);
        }

    }
}