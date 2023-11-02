using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Create(Usuario createDTO);
        Task<Usuario> Get(int id);
        Task<Usuario> Update(Usuario updateDTO);
        Task<bool> Delete(int id);
        Task<Usuario> UpdateById(int id, Usuario updateDTO);

        Task<Usuario> GetUserInfo(int id);
    }
}