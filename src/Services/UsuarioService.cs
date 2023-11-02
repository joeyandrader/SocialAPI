using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.ViewObjects;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Constructor
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper, IUserContextService userContextService)
        {
            _repository = repository;
            _mapper = mapper;
            _userContextService = userContextService;
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

        public async Task<Usuario> GetUserInfo()
        {
            var userId = _userContextService.GetUserContextData().Id;
            return await _repository.GetUserInfo(userId);
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



        public async Task<Usuario> UpdateById(int id, UsuarioVO updateDTO)
        {
            var userMap = _mapper.Map<Usuario>(updateDTO);
            return await _repository.UpdateById(id, userMap);
        }
    }
}