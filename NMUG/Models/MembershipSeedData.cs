using NMUG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace NMUG.Models
{
    public class MembershipSeedData

    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (context.Membership.Any())
                {
                    return;
                }
                context.Membership.AddRange(
                    new Membership

                    {
                        FirstName = "Bob",
                        LastName = "Murdock",
                        StreetAddress = "123 Main St",
                        City = "Rio Rancho",
                        State = "NM",
                        ZipCode = "87412",
                        Email = "bob.murdock@email.com",
                        PhoneNumber = "5052221213"



                    }
                    );
                context.SaveChanges();
            }
        }

    }
}