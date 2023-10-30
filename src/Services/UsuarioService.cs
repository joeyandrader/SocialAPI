using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Constructor
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        #endregion

        public async Task<Usuario> Create(Usuario createDTO)
        {
            createDTO.GeraPassHash(createDTO.Password);
            createDTO.CreatedAt = DateTime.UtcNow;
            createDTO.UpdateAt = DateTime.UtcNow;
            return await _repository.Create(createDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Usuario> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<Usuario> Update(Usuario updateDTO)
        {
            Usuario user = new Usuario()
            {
                Id = updateDTO.Id,
                FirstName = updateDTO.FirstName,
                LastName = updateDTO.LastName,
                Email = updateDTO.Email,
                Password = updateDTO.GeraPassHash(updateDTO.Password)
            };
            return await _repository.Update(user);
        }
    }
}