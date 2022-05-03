using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace test_case.Models
{
    public class Person
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string DisplayName { get; set; }

        [JsonPropertyName("skills") ]
        public virtual ICollection<PersonSkill>? PersonSkills { get; set; }
    }
}
