using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class PostService(IPostRepository _repository) : IPostService
    {
        public async Task<Post> CreateAsync(Post createDTO)
        {
            return await _repository.CreateAsync(createDTO);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Post> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Post> UpdateAsync(Post updateDTO)
        {
            return await _repository.UpdateAsync(updateDTO);
        }
    }
}
