using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VagasCom.Domain.Interfaces.Repositories;
using VagasCom.Domain.Interfaces.Services;
using VagasCom.Domain.Models.Profiles;
using VagasCom.Domain.Repositories;
using VagasCom.Domain.Services;

namespace VagasCom.Domain
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Configure basic Dependencies Injection like Services and Repositories
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDomainDependencies(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IApplicationsService, ApplicationsService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IVacanciesService, VacanciesService>();

            //Repositories
            services.AddScoped<IApplicationsRespository, ApplicationsRespository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IVacanciesRepository, VacanciesRepository>();

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            new BaseRepository().CreateSchemaDatabase();

            return services;
        }

        public static IServiceCollection ConfigureProfilesDependencies(this IServiceCollection services, List<Profile> profiles = null)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new VagasComProfile());
                if(profiles != null)
                profiles.ForEach(p => mc.AddProfile(p));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
