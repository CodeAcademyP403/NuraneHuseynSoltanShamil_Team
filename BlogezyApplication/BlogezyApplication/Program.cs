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
using Microsoft.EntityFrameworkCore;

namespace BlogezyApplication
{
    public class Program
    {
        public static IWebHost webhost;
        public static void Main(string[] args)
        {
             webhost = CreateWebHostBuilder(args).Build();

            //Seed Method for Creating some Articles, Users, and one Admin.

            Seed(webhost).GetAwaiter();

             webhost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();













        public async static Task Seed(IWebHost webhost)
        {
            using (IServiceScope scopedService = webhost.Services.CreateScope())
            {
                using (BlogezyDbContext dbContext = scopedService.ServiceProvider.GetRequiredService<BlogezyDbContext>())
                {
                    //ADDING SOME ARTICLES IF THERE ISN'T ANY IN DATABASE
                    if (!await dbContext.Articles.AnyAsync())
                    {
                        dbContext.Articles.AddRange(new List<Article>()
                        {
                            new Article(){Image = @"https://nomadicboys.com/wp-content/uploads/2015/12/Public-caning-in-Aceh-Indonesia-by-Sharia-police.jpg",
                                          Name ="LGBT Life in Indonesia",
                                          PublicDate = DateTime.Now,
                                          Category = "Life in Indonesia",
                                          Description =  
                                          #region Descritpion
                                          "Special police task forces have been set up to target LGBT activities in Indonesia. " +
                                          "Police recently arrested fifty-eight men after a police raid on a sauna in Jakarta." +
                                          "They accused the men of spreading naked images on social media and now the men" +
                                          " are facing up to 10 years in jail charged under the country’s pornography laws." +
                                          " Homosexuality is legal in most of Indonesia, but a case in the country’s top court may" +
                                          " criminalise homosexual acts. The United Nations has called on Indonesia " +
                                          "to stop the crackdown and to tackle anti-LGBT stigma."

                            
                            #endregion
                                          },
                             new Article(){Image = @"https://i.etsystatic.com/10656396/r/il/3295b3/1446321499/il_570xN.1446321499_inql.jpg",
                                          Name ="Fox in a Dishwasher",
                                          PublicDate = DateTime.Now,
                                          Category = "Animals",
                                          Description =  
                                          #region Descritpion
                                          "A fox cub, presumably looking for food, got itself stuck in a dishwasher in a London household. " +
                                          "Luckily for it, the owner found it and is a vet.With years of experience, " +
                                          "he could tell that the fox was just a few months old and seemed to be very scared. " +
                                          "He removed the dishwasher’s bottom trolley and, " +
                                          "after some persuasion with a sweeping brush, the frightened animal crept out of the appliance" +
                                          " and made a dash for the garden where people later saw it with its mother.."

                            
                            #endregion
                                          }

                        });
                        
                    }

                    //ADDING SOME USERS IF THERE ISN'T ANY IN DATABASE

                    if (!await dbContext.AppUsers.AnyAsync())
                    {
                        dbContext.AppUsers.AddRange(new List<AppUser>()
                        {
                            new AppUser(){UserName = "Huseyn", Email = "huseyinekh@code.edu.az", Role = Role.User, Password="Hh123456"},
                            new AppUser(){UserName = "Soltan", Email = "soltanaa@code.edu.az", Role = Role.User, Password="Ss123456"},
                            new AppUser(){UserName = "Nurana", Email = "nurananp@code.edu.az", Role = Role.User, Password="Nn123456"},
                            new AppUser(){UserName = "Shamil", Email = "shamilms@code.edu.az", Role = Role.User, Password="Ss123456"},
                            new AppUser(){UserName = "Admin", Email = "admin@code.edu.az", Role = Role.Admin, Password="admin"}

                        });
                    }

                    // ADDING SOME MENU items
                    if (!await dbContext.Menus.AnyAsync())
                    {
                        dbContext.Menus.AddRange(new List<Menu>()
                        {
                            new Menu(){Name = "Home", ActionName="",ControllerName = "", Visibility = true },
                            new Menu(){Name = "Features", ActionName="",ControllerName = "", Visibility = true },
                            new Menu(){Name = "Lifestyle", ActionName="",ControllerName = "", Visibility = true },
                            new Menu(){Name = "Music", ActionName="",ControllerName = "", Visibility = true },
                            new Menu(){Name = "Contacts", ActionName="",ControllerName = "", Visibility = true },
                            new Menu(){Name = "About", ActionName="About",ControllerName = "Home", Visibility = true },
                            new Menu(){Name = "Admin Panel", ActionName="AdminPanel",ControllerName = "Home", Visibility = false },


                        });
                    }
                    await dbContext.SaveChangesAsync();


                }



            }

        }
    }
}
