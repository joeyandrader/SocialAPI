using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Querys;
using System.Data;

namespace Infrastructure.Repositories
{
    public class PersonRepository(IDbConnection _connection) : IPersonRepository
    {
        public async Task<Person> CreateAsync(Person createDTO)
        {
            try
            {
                Person? result = await _connection.ExecuteScalarAsync<Person>(PersonQuery.Create(), new
                {
                    UserName = createDTO.UserName,
                    Email = createDTO.Email,
                    PasswordHash = createDTO.PasswordHash,
                    Bio = createDTO.Bio,
                    ProfileImg = createDTO.ProfilePictureUrl
                });

                if (result == null)
                    throw new Exception("Não foi possivel cadastrar o usuario!");

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
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
