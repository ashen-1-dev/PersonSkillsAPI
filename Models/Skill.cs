using System.ComponentModel.DataAnnotations;

namespace test_case.Models
{
    public class Skill
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<PersonSkill> PersonSkills { get; set; }

    }
}
