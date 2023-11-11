using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Repository;
using RedeSocialAPI.src.Services;

namespace RedeSocialAPI.src.Base.Ioc
{
    static class Ioc
    {
        public static void InjectionDependencie(IServiceCollection services)
        {
            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ILikeRepository, LikeRepository>();

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPhotosRepository, PhotoRepository>();
            services.AddScoped<ILikeService, LikeService>();
        }
    }
}