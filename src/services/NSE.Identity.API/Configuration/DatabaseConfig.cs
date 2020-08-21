using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identity.API.Configuration
{
    public static class DatabaseConfig
    {
        public static IApplicationBuilder UseCreateDatabase(this IApplicationBuilder builder)
        {


            return builder;
        }
    }
}
