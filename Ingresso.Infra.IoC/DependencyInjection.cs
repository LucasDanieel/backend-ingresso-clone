using Ingresso.Application.Authentication;
using Ingresso.Application.Authentication.Interfaces;
using Ingresso.Application.Caching;
using Ingresso.Application.Caching.Interfaces;
using Ingresso.Application.Mappings;
using Ingresso.Application.Services;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Integrations;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;
using Ingresso.Infra.Data.Integrations;
using Ingresso.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ingresso.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<ICinemaRoomRepository, CinemaRoomRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ISaveCloudinary, SaveCloudinary>();
            //services.AddScoped<ICachingService, CachingService>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<ICinemaRoomService, CinemaRoomService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRecaptchaService, RecaptchaService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
