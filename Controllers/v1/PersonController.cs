using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_case.database;
using test_case.Models;


namespace test_case.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext db = new PersonContext();

        // GET: api/v1/persons
        [HttpGet]
        [Route("~/api/v1/persons")]
        public dynamic Get()
        {
            //var person = new Person { Name = "John", DisplayName = "Jo" };
            //db.Persons.Add(person);
            //db.SaveChanges();

            //var skill = new Skill { Name = "Смышленный" };
            //var skill2 = new Skill { Name = "Находчивый" };
            //db.Skills.Add(skill);
            //db.Skills.Add(skill2);
            //db.SaveChanges();

            //var PersonSkill = new PersonSkill { PersonId = person.Id, SkillId = skill.Id, level = 5 };
            //var PersonSkill2 = new PersonSkill { PersonId = person.Id, SkillId = skill2.Id, level = 3 };
            //db.PersonSkills.Add(PersonSkill);
            //db.PersonSkills.Add(PersonSkill2);
            //db.SaveChanges();
            return Ok(db.Persons.Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.level
                })
            }));
        }

        // GET api/v1/person/5
        [HttpGet("{id}")]
        public dynamic Get(long id)
        {
            return Ok(db.Persons.Where(p => p.Id == id ).Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.level
                })
            }));
        }

        // POST api/v1/person
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return Ok("person created");
        }


        //PUT api/v1/person/5
        // TODO: Если добавить уже существующий у сотрудника навык выдаст ошибку
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Person person)
        {
            var personToUpdate = db.Persons.Find(id);
            if(personToUpdate == null)
                BadRequest("person not found");

            personToUpdate.Name = person.Name;
            personToUpdate.DisplayName = person.DisplayName;
            personToUpdate.PersonSkills = person.PersonSkills;
            db.SaveChanges();
            return Ok(db.Persons.Where(p => p.Id == id).Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.level
                })
            }));
        }

        // DELETE api/v1/person/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var person = db.Persons.Find(id);
            if (person == null)
                return NotFound("person not found");
            db.Persons.Remove(person);
            return Ok("this person was deleted");
        }
    }
}
