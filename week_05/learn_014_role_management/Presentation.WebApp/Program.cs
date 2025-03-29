using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DataContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/denied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
});


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Comment/UnComment if it's to be used or not.
// #region IdentityUser - RoleCreation
//
// // This creates roles if they do not exist, BUT, they do this check every time the application is run,
// // so one thing that one can do is to create the manual input functionality, and through that just have to use it once,
// // OR you can just start it once, and then comment out this whole section to be honest.
//
//
//     using (var scope = app.Services.CreateScope())
//     {
//         #region Create Roles
//
//             var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//             string[] roleNames = ["Administratör", "Användare"];
//
//             foreach (var roleName in roleNames)
//             {
//                 var roleExists = await roleManager.RoleExistsAsync(roleName);
//                 if (!roleExists)
//                 {
//                     await roleManager.CreateAsync(new IdentityRole(roleName));
//                 }
//             }
//
//         #endregion
//         
//         #region Create Administrator Account
//
//         var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//         var user = new ApplicationUser { UserName = "admin@domain.com", Email = "admin@domain.com" };
//
//         var userExists = await userManager.Users.AnyAsync(u => u.Email == user.Email);
//         if (!userExists)
//         {
//             var result = await userManager.CreateAsync(user, "BytMig123!");
//             if (result.Succeeded)
//                 await userManager.AddToRoleAsync(user, "Administratör");
//         }
//
//         #endregion
//     }
//
// #endregion


app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
