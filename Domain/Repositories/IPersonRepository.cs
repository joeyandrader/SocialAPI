using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> CreateAsync(Person createDTO);
        public Task<Person> UpdateAsync(int id, Person updateDTO);
        public Task<bool> DeleteAsync(int id);
        public Task<Person> GetAsync(int id);
        public Task<IEnumerable<Person>> GetAllAsync();
    }
}
