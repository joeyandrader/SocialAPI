using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository(IDbConnection _connection) : IPostRepository
    {
        public async Task<Post> CreateAsync(Post createDTO)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<Post>(PostQuery.Create(), createDTO);
            if (result == null)
                throw new Exception("Erro ao criar postagem!");
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<Post>(PostQuery.Get(), id);
            if (result == null)
                throw new Exception("Postagem não encontrada!");
            return await _connection.ExecuteAsync(PostQuery.Delete(), result.Id) > 0;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _connection.QueryAsync<Post>(PostQuery.GetAll());
        }

        public async Task<Post> GetAsync(int id)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<Post>(PostQuery.Get(), id);
            if (result == null)
                throw new Exception("Postagem não encontrada!");
            return result;
        }

        public async Task<Post> UpdateAsync(Post updateDTO)
        {
            Post? result = await _connection.QueryFirstOrDefaultAsync<Post>(PostQuery.Update(), updateDTO);
            if (result == null)
                throw new Exception("Erro ao atualizar a postagem");
            return result;
        }
    }
}
