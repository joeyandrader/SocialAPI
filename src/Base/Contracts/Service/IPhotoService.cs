using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Service
{
    public interface IPhotoService
    {
        Task<List<Photos>> Create(List<IFormFile> files, int postId);
        Task<Photos> Get(int id);
        Task<List<Photos>> GetAll();
        Task<Photos> Update(Photos updateDTO);
        Task<Photos> UpdateById(int id, Photos updateDTO);
        Task<bool> Delete(int id);
    }
}
