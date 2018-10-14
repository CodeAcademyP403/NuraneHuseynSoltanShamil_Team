using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogezyApplication.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlogezyApplication
{
    public class Program
    { 
        public static void Main(string[] args)
        {
          IWebHost webHost =   CreateWebHostBuilder(args).Build();


            using (IServiceScope scopedService = webHost.Services.CreateScope())
            {
                using (BlogezyDbContext dbContext = scopedService.ServiceProvider.GetRequiredService<BlogezyDbContext>())
                {
                    if (!dbContext.Articles.Any())
                    {

                        dbContext.Articles.AddRange(new List<Article>()
                        {
                            new Article(){}
                        });



                    }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
