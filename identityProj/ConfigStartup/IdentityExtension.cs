using identityProj.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identityProj.ConfigStartup
{
    public static class Extensions
    {
        public static IServiceCollection AddAthenticate(this IServiceCollection service)
        {
            service.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


            return service;
        }
    }
}
