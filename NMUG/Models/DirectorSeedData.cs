using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NMUG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMUG.Models
{
    public class DirectorSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (context.Directors.Any())
                {
                    return;
                }
                context.Directors.AddRange(
                    new Directors

                    {
                        TitleID = context.Title.Where(t => t.jobTitle == "President").FirstOrDefault().TitleID,
                        FirstName = "Tom",
                        LastName = "Murdock",
                        Email = "tom.murdock@nmug.net",
                        RoleDescription = "Responsible for just about everything.  Liason with INETA, Microsoft, and sponsors.",
                        Biography = ""

                    },
                     new Directors
                     {
                         TitleID = context.Title.Where(t => t.jobTitle == "Secretary").FirstOrDefault().TitleID,
                         FirstName = "Ludwig",
                         LastName = "Puchmayer",
                         Email = "ludwig.puchmayer@nmug.net",
                         RoleDescription = "Corporate Secretary for the New Mexico.NET Users Group",
                         Biography = ""


                     },
                     new Directors
                     {
                         TitleID = context.Title.Where(t => t.jobTitle == "Education and Program Director").FirstOrDefault().TitleID,
                         FirstName = "Randy",
                         LastName = "Fuller",
                         Email = "randy.fuller@nmug.net",
                         RoleDescription = "Responsible for the education programs sponsored by the New Mexico .NET Users Group.  Arranges speakers for the monthly meetings.",
                         Biography = ""
                         


                     }
                     );

               

                
                    

              

                context.SaveChanges(); 
                    
               
            }
        }
    }
}
