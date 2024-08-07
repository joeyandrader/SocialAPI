using Domain.Entities;
using Domain.Services;

namespace Application.Facade
{
    public class PostFacade(IPostService _service)
    {
        public async Task<Post> CreateAsync(Post createDTO)
        {
            return await _service.CreateAsync(createDTO);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _service.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        public async Task<Post> GetAsync(int id)
        {
            return await _service.GetAsync(id);
        }

        public async Task<Post> UpdateAsync(Post updateDTO)
        {
            return await _service.UpdateAsync(updateDTO);
        }
    }
}
