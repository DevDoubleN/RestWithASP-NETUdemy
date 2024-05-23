using Application.DTOs.Input.Person;
using Application.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : Controller
    {
        #region Properties
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        #endregion

        #region Constructor
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        #endregion

        #region Members of PersonController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post(PersonInsertDTO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put(PersonUpdateDTO person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Update(person));
        }

        /// <summary>
        /// Remove a person on the database
        /// </summary>
        /// <param name="id">Person identifier</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            _personService.Delete(id);

            return NoContent();
        }
        #endregion
    }
}
