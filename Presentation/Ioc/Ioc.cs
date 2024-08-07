using Application.Facade;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Repositories;

namespace Infrastructure.Ioc
{
    public static class Ioc
    {
        public static void LoadDependencyInjection(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPostService, PostService>();
            #endregion

            #region Facade
            services.AddScoped<PersonFacade>();
            services.AddScoped<PostFacade>();
            #endregion

            #region Repository
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            #endregion

        }
    }
}
