using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatersportsManager.API.Helpers;
using WatersportsManager.Application.People;
using WatersportsManager.Application.People.Models;
using WatersportsManager.Domain;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticatePerson([FromBody] PersonDto model)
        {
            if (model == null)
                return BadRequest();

            Person person = await _personService.AuthenticatePerson(model);

            if (person == null)
                return NotFound(new { Message = "Person Not Found!" });

            if (!PasswordHasher.VerifyPassword(model.Password, person.Password))
                return BadRequest(new { Message = "Password is Incorrect" });

            model.Token = _personService.CreateJwtToken(person);

            return Ok(new 
            {
                Token = model.Token,
                Message = "Login Success!" 
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPerson([FromBody] CreatePersonDto model, CancellationToken cancellationToken)
        {
            if (model == null)
                return BadRequest();

            // Check Username
            if (await _personService.CheckUsernameExistAsync(model.Username))
                return BadRequest(new { Message = "Username Already Exist!" });

            // Check Email
            if (await _personService.CheckEmailExistAsync(model.Email))
                return BadRequest(new { Message = "Email Already Exist!" });

            // Check password Strength
            var password = _personService.CheckPasswordStrength(model.Password);
            if(!string.IsNullOrEmpty(password))
                return BadRequest(new { Message = password });

            model.Password = PasswordHasher.HashPassword(model.Password);
            model.Token = "";

            await _personService.CreatePerson(model, cancellationToken);

            return Ok(new { Message = "User Registered!" });
        }

        [Authorize]
        [HttpGet (Name = nameof(GetPeople))]
        public async Task<IReadOnlyList<PersonDto>> GetPeople(CancellationToken cancellationToken)
        {
            return await _personService.GetPeople(cancellationToken);
        }

        [HttpGet("{id}", Name = nameof(GetPerson))]
        public async Task<IActionResult> GetPerson([FromRoute] int id, CancellationToken cancellationToken)
        {
            PersonDto person = await _personService.GetPersonById(id, cancellationToken);

            return person is not null ? Ok(person) : NotFound();
        }

        [HttpPost(Name = nameof(CreatePerson))]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto model, CancellationToken cancellationToken)
        {
            int personId = await _personService.CreatePerson(model, cancellationToken);

            return CreatedAtAction(nameof(CreatePerson), new { Id = personId });
        }

        [HttpPut(Name = nameof(UpdatePerson))]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDto model, CancellationToken cancellationToken)
        {
            await _personService.UpdatePerson(model, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeletePerson))]
        public async Task<IActionResult> DeletePerson([FromRoute] int id, CancellationToken cancellationToken)
        {
            bool personDeleted = await _personService.DeletePerson(id, cancellationToken);

            return personDeleted ? NoContent() : NotFound();
        }
    }
}
