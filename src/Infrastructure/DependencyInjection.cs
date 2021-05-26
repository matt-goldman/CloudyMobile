using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Infrastructure.Identity;
using CloudyMobile.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CloudyMobile.Infrastructure
{
    public static class ConfigureServices
    {
        private static string WEBSITE_PRIVATE_CERTS_PATH { get; set; } = String.Empty;
        private static string IDS_CERT_THUMBPRINT { get; set; } = String.Empty;
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

            if(environment.IsProduction())
            {
                // adding this compiler directive in addition to environment.IsProduction
                // as the Nswag.MsBuild task fails without it. The Nswag task relies on
                // Configuration rather than environment.
#if !DEBUG
                Console.WriteLine("Running in production environment.");

                WEBSITE_PRIVATE_CERTS_PATH = configuration.GetValue<string>(nameof(WEBSITE_PRIVATE_CERTS_PATH));

                IDS_CERT_THUMBPRINT = configuration.GetValue<string>(nameof(IDS_CERT_THUMBPRINT));

                var certPath = Path.Combine(WEBSITE_PRIVATE_CERTS_PATH, IDS_CERT_THUMBPRINT, ".pfx");

                var certBytes = File.ReadAllBytes(certPath);

                var cert = new X509Certificate2(certBytes);

                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                    .AddSigningCredential(cert); 
#endif
            }
            else
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            }

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}