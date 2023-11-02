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
    public class PhotoRepository : IPhotosRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public PhotoRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Create a new photo
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        public async Task<Photos> Create(Photos createDTO)
        {
            _context.Fotos.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }

        /// <summary>
        /// Remove a photo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> <summary>
        public async Task<bool> Delete(int id)
        {
            var fotos = await _context.Fotos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (fotos != null)
                _context.Fotos.Remove(fotos);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Get a photo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Photos> Get(int id)
        {
            var fotos = await _context.Fotos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (fotos == null)
                throw new Exception("Foto não encontrado");
            return fotos;
        }

        /// <summary>
        /// List photos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Photos>> GetAll()
        {
            var foto = await _context.Fotos.ToListAsync();
            if (foto == null)
                throw new Exception("Nenhuma foto encontrada");
            return foto;
        }

        /// <summary>
        /// Update a photo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        public async Task<Photos> Update(Photos updateDTO)
        {
            _context.Fotos.Update(updateDTO);
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
        public async Task<Photos> UpdateById(int id, Photos updateDTO)
        {
            var source = await _context.Fotos.FirstOrDefaultAsync(x => x.Id == id);
            if (source == null)
            {
                throw new Exception("Dados não encontrado");
            }
            source = Utils.MapTo(source, updateDTO);
            await _context.SaveChangesAsync();
            return source;
        }
    }
}