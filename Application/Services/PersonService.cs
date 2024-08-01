using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class PersonService(IPersonRepository _repository) : IPersonService
    {
        public async Task<Person> CreateAsync(Person createDTO)
        {
            return await _repository.CreateAsync(createDTO);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Person> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Person> UpdateAsync(int id, Person updateDTO)
        {
            return await _repository.UpdateAsync(id, updateDTO);
        }
    }
}
