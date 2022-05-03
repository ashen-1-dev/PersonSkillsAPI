using Microsoft.AspNetCore.Mvc;
using test_case.database;
using test_case.Models;

namespace test_case.Controllers.v1
{
    [Route("api/v1/[controller]")]
    
    public class SkillController : ControllerBase
    {
        private readonly PersonContext _db = new PersonContext();
        [HttpPost]
        public ActionResult<Skill> Post([FromBody]Skill skill)
        {
            _db.Skills.Add(skill);
            _db.SaveChanges();
            return Ok(skill);
        }
    }
}
