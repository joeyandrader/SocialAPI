using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.ViewObjects;

namespace RedeSocialAPI.src.Base.Contracts.Service
{
    public interface IUsuarioService
    {
        Task<Usuario> Create(Usuario createDTO);
        Task<Usuario> Get(int id);
        Task<Usuario> Update(Usuario updateDTO);
        Task<bool> Delete(int id);
        Task<Usuario> UpdateById(int id, UsuarioVO updateDTO);

        Task<Usuario> GetUserInfo();
    }
}