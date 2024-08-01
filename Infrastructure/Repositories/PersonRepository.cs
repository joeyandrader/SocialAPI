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
                var result = await _connection.QueryFirstOrDefaultAsync<Person>(PersonQuery.Create(), new
                {
                    UserName = createDTO.UserName,
                    Email = createDTO.Email,
                    PasswordHash = createDTO.PasswordHash,
                    Bio = createDTO.Bio,
                    ProfileUrl = createDTO.ProfilePictureUrl
                });

                if (result == null)
                    throw new Exception("Não foi possivel cadastrar o usuario!");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _connection.ExecuteAsync(PersonQuery.Delete(), new
            {
                Id = id
            });
            if (result == 0)
                throw new Exception("Erro ao deletar usuario!");
            return result == 1;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _connection.QueryAsync<Person>(PersonQuery.GetAll());
        }

        public async Task<Person> GetAsync(int id)
        {
            try
            {
                Person? result = await _connection.QueryFirstOrDefaultAsync<Person>(PersonQuery.Get(), new
                {
                    Id = id
                });

                if (result == null)
                    throw new Exception("Usuario não encontrado!");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> UpdateAsync(int id, Person updateDTO)
        {
            Person? result = await _connection.QueryFirstOrDefaultAsync<Person>(PersonQuery.Update(), new
            {
                UserName = updateDTO.UserName,
                Email = updateDTO.Email,
                PasswordHash = updateDTO.PasswordHash,
                Bio = updateDTO.Bio,
                ProfilePictureUrl = updateDTO.ProfilePictureUrl,
                Id = id
            });

            if (result == null)
                throw new Exception("Erro ao atualizar usuario!");

            return result;
        }
    }
}
