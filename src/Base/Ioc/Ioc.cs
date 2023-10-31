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

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}