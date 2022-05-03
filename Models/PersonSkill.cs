using System.ComponentModel.DataAnnotations;

namespace test_case.Models
{
    public class PersonSkill
    {
        public long PersonId { get; set; }
        public virtual Person? Person { get; set; }
        public long SkillId { get; set; }
        public virtual Skill? Skill {get; set; }
        [Range(1, 10)]
        public byte level { get; set; }

    }
}
