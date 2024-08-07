using Domain.Entities;

namespace Domain.Services
{
    public interface IPostService
    {
        Task<Post> CreateAsync(Post createDTO);
        Task<Post> UpdateAsync(Post updateDTO);
        Task<bool> DeleteAsync(int id);
        Task<Post> GetAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
    }
}
