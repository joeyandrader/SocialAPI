
using Domain.Entities;

namespace Domain.Services;

public interface IPersonService
{
    public Task<Person> CreateAsync(Person createDTO);
    public Task<Person> UpdateAsync(int id, Person updateDTO);
    public Task<bool> DeleteAsync(int id);
    public Task<Person> GetAsync(int id);
    public Task<IEnumerable<Person>> GetAllAsync();
}
