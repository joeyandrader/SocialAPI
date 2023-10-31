using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.DB;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        public async Task<Usuario> Create(Usuario createDTO)
        {
            _context.Usuarios.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }

        /// <summary>
        /// Remove an user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> <summary>
        public async Task<bool> Delete(int id)
        {
            var user = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
                _context.Usuarios.Remove(user);
            return (await _context.SaveChangesAsync()) > 0;
        }

        /// <summary>
        /// Get an user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Usuario> Get(int id)
        {
            var user = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
                throw new Exception("Usuario não encontrado");
            return user;
        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        public async Task<Usuario> Update(Usuario updateDTO)
        {
            _context.Usuarios.Update(updateDTO);
            await _context.SaveChangesAsync();
            return updateDTO;
        }

        /// <summary>
        ///  Update a patch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Usuario> UpdateById(int id, Usuario updateDTO)
        {
            var source = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (source == null)
            {
                throw new Exception("Dados não encontrado");
            }
            source = Utils.MapTo(source, updateDTO);
            if (updateDTO.Password != null)
                source.ChangePropertyValue("Password", CryptPassword.GerarHash(updateDTO.Password));
            await _context.SaveChangesAsync();
            return source;
        }
    }
}