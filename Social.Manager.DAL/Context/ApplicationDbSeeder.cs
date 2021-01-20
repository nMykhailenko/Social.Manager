using Social.Manager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Manager.DAL.Context
{
    public class ApplicationDbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.PersonnalInformations.Any())
            {
                for (var i = 0; i < 50; i++)
                {
                    var entity = new PersonalInformation
                    {
                        Address = $"address {i}",
                        Email = $"email{i}@email.com",
                        FacebookLink = i % 2 == 0 ? string.Empty : $"facebook-link-{i}",
                        FirstName = $"FName {i}",
                        LastName = $"LName {i}",
                        PhoneNumber = $"phonenumber-{i}",
                        TwitterLink = $"twitter-link-{i}"
                    };

                    context.PersonnalInformations.Add(entity);
                }

                context.SaveChanges();
            }
        }
    }
}
