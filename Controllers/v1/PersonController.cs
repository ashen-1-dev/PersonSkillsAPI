using Microsoft.AspNetCore.Mvc;
using test_case.database;
using test_case.Models;


namespace test_case.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _db = new PersonContext();

        // GET: api/v1/persons
        [HttpGet]
        [Route("~/api/v1/persons")]
        public ActionResult Get()
        {
            return Ok(_db.Persons.Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.Level
                })
            }));
        }

        // GET api/v1/person/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            return Ok(_db.Persons.Where(p => p.Id == id ).Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.Level
                })
            }));
        }

        // POST api/v1/person
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
            return Ok(_db.Persons.Where(p => p.Id == person.Id).Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.Level
                })
            }));
        }


        //PUT api/v1/person/5
        // TODO: Если добавить уже существующий у сотрудника навык выдаст ошибку
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Person person)
        {
            var personToUpdate = _db.Persons.Find(id);
            if(personToUpdate == null)
                BadRequest("person not found");

            personToUpdate.Name = person.Name;
            personToUpdate.DisplayName = person.DisplayName;
            personToUpdate.PersonSkills = person.PersonSkills;
            _db.SaveChanges();
            return Ok(_db.Persons.Where(p => p.Id == id).Select(p => new
            {
                p.Id,
                p.Name,
                p.DisplayName,
                Skills = p.PersonSkills.Select(ps => new
                {
                    ps.Skill.Name,
                    ps.Level
                })
            }));
        }

        // DELETE api/v1/person/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var person = _db.Persons.Find(id);
            if (person == null)
                return NotFound("person not found");
            _db.Persons.Remove(person);
            return Ok("this person was deleted");
        }
    }
}
