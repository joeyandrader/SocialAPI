using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.DB;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Repository
{
    public class PostRepository : IPostRepository
    {
        #region Constructor
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<Post> Create(Post createDTO)
        {
            _context.Postagem.Add(createDTO);
            await _context.SaveChangesAsync();
            return createDTO;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _context.Postagem.Where(post => post.Id == id).FirstOrDefaultAsync();
            if (post == null)
                return false;
            _context.Postagem.Remove(post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Post> Get(int id)
        {
            var post = await _context.Postagem.Where(post => post.Id == id)
                .Include(foto => foto.Fotos)
                .FirstOrDefaultAsync();
            if (post == null)
                throw new Exception("Postagem não encontrada!");
            return post;
        }

        public async Task<List<Post>> List()
        {
            var listPost = await _context.Postagem.ToListAsync();
            if (!listPost.Any())
                throw new Exception("Não ah nenhuma postagem");
            return listPost;
        }

        public async Task<Post> Update(Post updateDTO)
        {
            _context.Postagem.Update(updateDTO);
            await _context.SaveChangesAsync();
            return updateDTO;
        }

        public async Task<Post> UpdateById(int id, Post updateDTO)
        {
            var source = await _context.Postagem.Where(post => post.Id == id).FirstOrDefaultAsync();
            if (source == null)
                throw new Exception("Dados não encontrado");
            source = Utils.MapTo(source, updateDTO);
            await _context.SaveChangesAsync();
            return source;
        }
    }
}
