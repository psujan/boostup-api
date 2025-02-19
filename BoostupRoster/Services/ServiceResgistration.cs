using Boostup.API.Data;
using Boostup.API.Entities;
using Boostup.API.Interfaces.Auth;
using Boostup.API.Repositories.Auth;
using Microsoft.AspNetCore.Identity;

namespace Boostup.API.Services
{
    public static class ServiceResgistration
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, WebApplicationBuilder builder) 
        {
            services.AddScoped<IUserManagerRepository, UserManagerRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddIdentity<User, IdentityRole>()
                   .AddRoles<IdentityRole>()
                   .AddTokenProvider<DataProtectorTokenProvider<User>>("Boostup")
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();
            return services;
        }
    }
}
