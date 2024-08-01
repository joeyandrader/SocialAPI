using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService(IPersonRepository _repository) : IPersonService
    {
        public async Task<Person> CreateAsync(Person createDTO)
        {
            return await _repository.CreateAsync(createDTO);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(int id, Person updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
