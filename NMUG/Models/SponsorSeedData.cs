using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NMUG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMUG.Models
{
    public class SponsorSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (context.Sponsor.Any())
                {
                    return;
                }
                
                   context.Sponsor.AddRange(
                    new Sponsor

                    {

                        CompanyName = "Pizza 9",
                        SponsorLevel = "Platinum"

                    },
                    new Sponsor

                    {

                        CompanyName = "DiscountASP.Net",
                        SponsorLevel = "Platinum"

                    },
                    new Sponsor

                    {

                        CompanyName = "Infragistics",
                        SponsorLevel = "Platinum"

                    },
                    new Sponsor

                    {

                        CompanyName = "telerik",
                        SponsorLevel = "Platinum"

                    },
                    new Sponsor

                    {

                        CompanyName = "ComponentOne",
                        SponsorLevel = "Platinum"

                    },
                    new Sponsor

                    {

                        CompanyName = "Nevron",
                        SponsorLevel = "Platinum"

                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
    

