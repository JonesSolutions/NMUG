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
                        Description = "Responsible for just about everything.  Liason with INETA, Microsoft, and sponsors.",
                        Email = "tom.murdock@nmug.net"
                    },
                     new Directors
                     {
                         TitleID = context.Title.Where(t => t.jobTitle == "Secretary").FirstOrDefault().TitleID,
                         FirstName = "Ludwig",
                         LastName = "Puchmayer",
                         Description = "Corporate Secretary for the New Mexico.NET Users Group",
                         Email = "ludwig.puchmayer@nmug.net"
                     
                      
                    },
                     new Directors
                     {
                         TitleID = context.Title.Where(t => t.jobTitle == "Education and Program Director").FirstOrDefault().TitleID,
                         FirstName = "Randy",
                         LastName = "Fuller",
                         Description = "Responsible for the education programs sponsored by the New Mexico .NET Users Group.  Arranges speakers for the monthly meetings.",
                         Email = "randy.fuller@nmug.net"


                     }
                     );

               

                
                    

              

                context.SaveChanges(); 
                    
               
            }
        }
    }
}
