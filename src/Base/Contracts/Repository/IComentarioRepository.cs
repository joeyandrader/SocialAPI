using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Repository
{
    public interface IComentarioRepository
    {
        Task<Comentarios> Create(Comentarios createDTO);
        Task<Comentarios> Get(int id);
        Task<List<Comentarios>> GetAll();
        Task<Comentarios> Update(Comentarios updateDTO);
        Task<Comentarios> UpdateById(int id, Comentarios updateDTO);
        Task<bool> Delete(int id);
    }
}
