using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Repository
{
    public interface IPhotosRepository
    {
        Task<Photos> Create(Photos createDTO);
        Task<Photos> Get(int id);
        Task<List<Photos>> GetAll();
        Task<Photos> Update(Photos updateDTO);
        Task<Photos> UpdateById(int id, Photos updateDTO);
        Task<bool> Delete(int id);
    }
}
