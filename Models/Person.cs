using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace test_case.Models
{
    public class Person
    {
        [BindNever]
        public long Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public virtual ICollection<PersonSkill> PersonSkills { get; set; }
    }
}
