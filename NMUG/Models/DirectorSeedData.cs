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
            using (var _context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (_context.Directors.Any())
                {
                    return;
                }



                _context.Directors.AddRange(
                    new Directors
                    {

                        TitleID = _context.Titles.Where(t => t.jobTitle == "President").FirstOrDefault().TitleID,
                        FirstName = "Louis",
                        LastName = "Stevens",
                        Description = "Responsible for everything. Everything.  I'm talking EVERYTHING.",
                        Email = "email@email.com"


                    });
                _context.SaveChanges();


            }
        }
    }
}

