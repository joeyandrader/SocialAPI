using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.DB;

namespace RedeSocialAPI.src.Repository
{
    public class LikeRepository : ILikeRepository
    {
        #region Constructor
        private readonly DataContext _context;
        private readonly IUserContextService _userContextService;
        public LikeRepository(DataContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }
        #endregion


        public async Task<Like> Create(Like createDTO)
        {
            _context.Like.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }

        public async Task<bool> Delete(int id)
        {
            var like = await _context.Like.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (like == null)
                throw new Exception("Like não encontrado");
            _context.Like.Remove(like);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Like> Get(int id)
        {
            var like = await _context.Like.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (like == null)
                throw new Exception("Like não encontrado");
            return like;
        }

        public Task<List<Like>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica se ja existe um like com esse usuario
        /// </summary>
        /// <returns></returns>
        public async Task<Like> GetExistLike(int postId)
        {
            var userId = _userContextService.GetUserContextData().Id;
            var getLike = await _context.Like.Where(x => x.UsuarioId == userId && x.PostId == postId).FirstOrDefaultAsync();
            if (getLike == null)
                return null;
            return getLike;
        }

        public Task<Like> Update(Like updateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Like> UpdateById(int id, Like updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
