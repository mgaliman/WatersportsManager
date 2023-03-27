using WatersportsManager.Application.People.Models;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.People
{
    public interface IPersonService
    {
        public Task<Person> AuthenticatePerson(PersonDto person);
        public Task<bool> CheckUsernameExistAsync(string username);
        public Task<bool> CheckEmailExistAsync(string username);
        public string CheckPasswordStrength(string username);
        public string CreateJwtToken(Person person);
        public Task<IReadOnlyList<PersonDto>> GetPeople(CancellationToken token);
        public Task<PersonDto> GetPersonById(int id, CancellationToken token);
        public Task<int> CreatePerson(CreatePersonDto person, CancellationToken token);
        public Task UpdatePerson(UpdatePersonDto person, CancellationToken token);
        public Task<bool> DeletePerson(int id, CancellationToken token);
        public Task<bool> PersonExists(int id, CancellationToken token);
    }
}
