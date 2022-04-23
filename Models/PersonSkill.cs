using System.ComponentModel.DataAnnotations;

namespace test_case.Models
{
    public class PersonSkill
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public long SkillId { get; set; }
        public Skill Skill {get; set; }

        public string level { get; set; }

    }
}
