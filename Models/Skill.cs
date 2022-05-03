namespace test_case.Models
{
    public class Skill
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PersonSkill> PersonSkills { get; set; }

    }
}
