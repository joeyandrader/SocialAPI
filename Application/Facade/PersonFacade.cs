using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Facade
{
    public class PersonFacade(IPersonService _personService)
    {
        public async Task<Person> CreateAsync(Person createDTO)
        {
            return await _personService.CreateAsync(createDTO);
        }

        public async Task<Person> GetAsync(int id)
        {
            return await _personService.GetAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _personService.GetAllAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _personService.DeleteAsync(id);
        }

        public async Task<Person> UpdateAsync(int id, Person updateDTO)
        {
            return await _personService.UpdateAsync(id, updateDTO);
        }
    }
}
