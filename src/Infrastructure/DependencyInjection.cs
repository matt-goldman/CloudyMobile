using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Infrastructure.Identity;
using CloudyMobile.Infrastructure.Persistence;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CloudyMobile.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => 
                provider.GetRequiredService<ApplicationDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

                services.AddIdentityServer()
                    .AddInMemoryClients(new List<Client>
                    {
                        new Client
                        {
                            ClientId = "CloudyMobile.Maui",
                            AllowedGrantTypes = GrantTypes.Code,
                            RequireClientSecret = false,
                            AllowedScopes = { "openid", "profile", "CloudyMobile.APIAPI" },
                            RedirectUris = { "auth.com.ssw.cloudymobile.maui://callback" },
                            AllowOfflineAccess = true,
                            AllowAccessTokensViaBrowser = true,
                            Enabled = true
                        }
                    }) //(configuration.GetSection("IdentityServer:Clients"))
                    .AddInMemoryIdentityResources(new List<IdentityResource>
                    {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile()
                    })
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}