using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new RazorPagesDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesDbContext>>()))
            {
               if (context.Students.Any())  
               {
                   return;
               }   

               context.Students.AddRange(
                   new Models.Student
                   {
                       FirstName = "Nicola",
                       LastName = "Skinner",
                       GPA = 4.0
                   },
                   
                   new Models.Student
                   {
                       FirstName = "Dominic",
                       LastName = "Langton",
                       GPA = 3.0
                   },

                   new Models.Student
                   {
                       FirstName = "Dorothy",
                       LastName = "May",
                       GPA = 3.5
                   },

                   new Models.Student
                   {
                       FirstName = "Keith",
                       LastName = "Martin",
                       GPA = 2.0
                   },

                   new Models.Student
                   {
                       FirstName = "Oliver",
                       LastName = "Pullman",
                       GPA = 2.5
                   },

                   new Models.Student
                   {
                       FirstName = "Boris",
                       LastName = "Reid",
                       GPA = 1.5
                   },

                   new Models.Student
                   {
                       FirstName = "Sam",
                       LastName = "North",
                       GPA = 2.5
                   }
               );

               context.SaveChanges();
            }
        }
    }
}