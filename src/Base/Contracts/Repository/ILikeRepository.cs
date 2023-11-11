using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Repository
{
    public interface ILikeRepository
    {
        Task<Like> Create(Like createDTO);
        Task<Like> Get(int id);
        Task<List<Like>> GetAll();
        Task<Like> Update(Like updateDTO);
        Task<Like> UpdateById(int id, Like updateDTO);
        Task<bool> Delete(int id);
        Task<Like> GetExistLike(int postId);
    }
}
