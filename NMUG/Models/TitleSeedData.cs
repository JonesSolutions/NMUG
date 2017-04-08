using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NMUG.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NMUG.Models
{
    public class TitleSeedData
    {
        // GET: /<controller>/
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (context.Title.Any())
                {
                    return;
                }
                context.Title.AddRange(
                    new Title

                    {
                       
                        jobTitle = "President"

                    },

                    new Title
                    {
                        
                        jobTitle = "Secretary"
                    },

                    new Title
                    {
                        
                        jobTitle = "Education and Program Director"
                    },
                    new Title
                    {

                        jobTitle = "Education"
                    },
                    new Title
                    {

                        jobTitle = "Program Director"
                    },
                    new Title
                    {
                       
                        jobTitle = "Treasurer and Membership Director"
                    },
                    new Title
                    {

                        jobTitle = "Treasurer"
                    },
                    new Title
                    {

                        jobTitle = "Membership Director"
                    },
                    new Title
                    {
                        
                        jobTitle = "Webmaster"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
