#nullable disable warnings

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using WatersportsManager.Application.People.Models;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.People
{
    public class PersonService : IPersonService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public PersonService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> AuthenticatePerson(PersonDto person)
        {
            return await _dbContext.People.FirstOrDefaultAsync(x => x.Username == person.Username);
        }

        public async Task<bool> CheckUsernameExistAsync(string username)
        {
            return await _dbContext.People.AnyAsync(x => x.Username == username);
        }
        
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _dbContext.People.AnyAsync(x => x.Email == email);
        }
        
        public string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);

            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,˛~,`,-,=]"))
                sb.Append("Password should contain special characters" + Environment.NewLine);

            return sb.ToString();
        }

        public string CreateJwtToken(Person person)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");

            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, $"{(person.RoleId == 2 ? "ADMIN" : "USER")}"),
                new Claim(ClaimTypes.Name, $"{person.FirstName} {person.LastName}"),
                new Claim("Id", $"{person.Id}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        public async Task<IReadOnlyList<PersonDto>> GetPeople(CancellationToken token)
        {
            return await _dbContext.People.AsNoTracking()
               .Select(person => new PersonDto
               {
                   Id = person.Id,
                   FirstName = person.FirstName,
                   LastName = person.LastName,
                   IsSkipper = person.IsSkipper,
                   Username = person.Username,
                   Password = person.Password,
                   Token = person.Token,
                   Email = person.Email,
                   Role = person.Role.Code,
                   Location = person.Location.Camp
               })
               .ToListAsync(token);
        }

        public async Task<PersonDto> GetPersonById(int id, CancellationToken token)
        {
            return await _dbContext.People.Where(person => person.Id == id)
               .Select(person => new PersonDto
               {
                   Id = person.Id,
                   FirstName = person.FirstName,
                   LastName = person.LastName,
                   IsSkipper = person.IsSkipper,
                   Username = person.Username,
                   Password = person.Password,
                   Token = person.Token,
                   Email = person.Email,
                   Role = person.Role.Code,
                   Location = person.Location.Camp
               })
               .FirstOrDefaultAsync(token);
        }

        public async Task<int> CreatePerson(CreatePersonDto person, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(person, nameof(person));

            Person personToCreate = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                IsSkipper = person.IsSkipper == null ? false : person.IsSkipper,
                Username = person.Username,
                Password = person.Password,
                Token = person.Token,
                Email = person.Email,
                RoleId = person.RoleId == 0 ? 1 : person.RoleId,
                LocationId = person.LocationId
            };

            _dbContext.Add(personToCreate);

            await _dbContext.SaveChangesAsync(token);

            return personToCreate.Id;
        }

        public async Task UpdatePerson(UpdatePersonDto person, CancellationToken token)
        {
            Person personToUpdate = await _dbContext.People.FindAsync(new object[] { person.Id }, cancellationToken: token);

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.IsSkipper = person.IsSkipper;
            personToUpdate.Username = person.Username;
            personToUpdate.Password = person.Password;
            personToUpdate.Token = person.Token;
            personToUpdate.Email = person.Email;
            personToUpdate.RoleId = person.RoleId;
            personToUpdate.LocationId = person.LocationId;

            await _dbContext.SaveChangesAsync(token);
        }
        
        public async Task<bool> DeletePerson(int id, CancellationToken token)
        {            
            Person personToDelete = await _dbContext.People.Where(person => person.Id == id ).FirstOrDefaultAsync(token);
            if (personToDelete is null)
                return false;
        
            _dbContext.People.Remove(personToDelete); 
            await _dbContext.SaveChangesAsync(token);

            return true;
        }
        
        public async Task<bool> PersonExists(int id, CancellationToken token)
        {
            return await _dbContext.People.Where(person => person.Id == id).AnyAsync(token);
        }
    }
}