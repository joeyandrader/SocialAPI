using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.Request;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.DB;

namespace RedeSocialAPI.src.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Usuario> Auth(AuthRequest request)
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.Where(x => x.Email == request.Email);
            if (query == null)
                throw new Exception("Dados invalido, ou usuario não existe");
            return await query.FirstOrDefaultAsync();
        }
    }
}
