using CustomerEntitites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation
{
    public class Program
    {
        private static CustomerEntities _customerContext;

        public static CustomerEntities CustomerContext
        {
            get
            {
                if (_customerContext == null)
                    _customerContext = new CustomerEntities(null);
                return _customerContext;
            }
            set { _customerContext = value; }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
