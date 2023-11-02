using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Service
{
    public interface IPostService
    {
        Task<Post> Create(Post createDTO);
        Task<Post> Update(Post updateDTO);
        Task<Post> UpdateById(int id, Post updateDTO);
        Task<bool> Delete(int id);
        Task<Post> Get(int id);
        Task<List<Post>> List();
    }
}
