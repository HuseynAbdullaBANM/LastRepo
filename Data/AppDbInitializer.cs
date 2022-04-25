using Bhosphor_Ecoshop.Data.Static;
using Bhosphor_Ecoshop.Models;
using Microsoft.AspNetCore.Identity;

namespace Bhosphor_Ecoshop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Accessory",
                            Description = "This type of products can be used in your cars, houses, etc."
                        },
                        new Category()
                        {
                            Name = "Domestic",
                            Description = "You can use these products in your rooms"
                        },
                        new Category()
                        {
                            Name = "Office",
                            Description = "This type of products can be used in your workplace"
                        },
                    });
                    context.SaveChanges();
                }

                //Sellers
                if (!context.Sellers.Any())
                {
                    context.Sellers.AddRange(new List<Seller>()
                    {
                        new Seller()
                        {
                            FirstName = "Huseyn",
                            LastName = "Abdullayev",
                            ProfilePictureUrl = "https://imgs.search.brave.com/vpt6wiHR9SihhRVcIL-fYFd2qHnL9E1w2QMRt7kH7fE/rs:fit:860:900:1/g:ce/aHR0cHM6Ly93d3cu/cG5naXRlbS5jb20v/cGltZ3MvbS8zMC0z/MDE5NDdfZWNvLWZy/aWVuZGx5LWxvZ28t/cG5nLWZyZWUtZWNv/LWZyaWVuZGx5LWxv/Z28ucG5n",
                            Bio = "Curious BHOS student"
                        },
                        new Seller()
                        {
                            FirstName = "Ilaha",
                            LastName = "Gardashaliyeva",
                            ProfilePictureUrl = "https://imgs.search.brave.com/SpmqIAxfPKFjowrAhF0WqgigWU3hkxquFbcO5Ax4I_g/rs:fit:1024:576:1/g:ce/aHR0cHM6Ly9pbnRl/cmNhcmQuY28udWsv/d3AtY29udGVudC91/cGxvYWRzLzIwMjAv/MDIvRW52aXJvbm1l/bnRhbGx5LUZyaWVu/ZGx5LUNhcmRzLUlh/Z2UtMTAyNHg1NzYu/cG5n",
                            Bio = "Curious BHOS student"
                        },
                        new Seller()
                        {
                            FirstName = "Aytac",
                            LastName = "Kazimli",
                            ProfilePictureUrl = "https://imgs.search.brave.com/OISBANuF4yvL7QOouBBYbRLcczy8vaMaYyj6bdY8mUU/rs:fit:711:225:1/g:ce/aHR0cHM6Ly90c2Ux/Lm1tLmJpbmcubmV0/L3RoP2lkPU9JUC5U/Ylh6MDlXbzhsMVhm/SUhUMTcyMXdnSGFF/OCZwaWQ9QXBp",
                            Bio = "Curious BHOS student"
                        },
                    });
                    context.SaveChanges();
                }

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Clean Essentials Kit",
                            Description = "The eco-friendly brand streamlines green cleaning by using reusable bottles and dissolvable tablets",
                            Price = 39,
                            ImageURL = "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1642793525-2350573f482a079f48e026dfc5317ec21df9d648-1720x1590.jpg?crop=0.950xw:1.00xh",
                            StartDate = DateTime.Now.AddDays(3),
                            CategoryId=1,
                            SellerId=1,
                        },
                        new Product()
                        {
                            Name = "Spaghetti Scrubs",
                            Description = "It's comprised of cotton strips and pulverized, dried corn cobs",
                            Price = 10,
                            ImageURL = "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1619458213-3ccbf650-398d-46ef-ac79-4ab3f7f1-1619458199.jpg?crop=1xw:1xh",
                            StartDate = DateTime.Now.AddDays(4),
                            CategoryId=2,
                            SellerId=2,
                        },
                        new Product()
                        {
                            Name = "Dish Washing Block Soap",
                            Description = " It provides the same fresh clean without the plastic packaging or mystery ingredients.",
                            Price = 10,
                            ImageURL = "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1642706127-31GI79mO8L._SL500_.jpg?crop=1.00xw:0.938xh",
                            StartDate = DateTime.Now.AddDays(5),
                            CategoryId=3,
                            SellerId=3,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "AdminUser",
                        SecondName = "AdminUser",
                        PhoneNumber = "+994707004433",
                        Location = "Baku",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }



                string appUserEmail = "user@etickets.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirstName = "AppUser",
                        SecondName = "AppUser",
                        PhoneNumber = "+994707004433",
                        Location= "Baku",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
