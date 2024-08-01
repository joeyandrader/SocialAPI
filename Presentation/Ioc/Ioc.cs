using Application.Facade;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc
{
    public static class Ioc
    {
        public static void LoadDependencyInjection(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IPersonService, PersonService>();
            #endregion

            #region Facade
            services.AddScoped<PersonFacade>();
            #endregion

            #region Repository
            services.AddScoped<IPersonRepository, PersonRepository>();
            #endregion

        }
    }
}
