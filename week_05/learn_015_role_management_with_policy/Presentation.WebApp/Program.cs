using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/auth/login";
    options.AccessDeniedPath = "/denied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Managers", policy => policy.RequireRole("Admin", "Manager"));
    options.AddPolicy("Authenticated", policy => policy.RequireRole("Admin", "Manager", "User"));
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
//             string[] roleNames = ["Admin", "Manager", "User"];
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
//             var userManagerAdmin = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//             var adminUser = new ApplicationUser { FirstName = "Primary", LastName = "Admin", UserName = "admin@domain.com", Email = "admin@domain.com" };
//
//             var adminExists = await userManagerAdmin.Users.AnyAsync(u => u.Email == adminUser.Email);
//             if (!adminExists)
//             {
//                 var result = await userManagerAdmin.CreateAsync(adminUser, "BytMig123!");
//                 if (result.Succeeded)
//                     await userManagerAdmin.AddToRoleAsync(adminUser, "Admin");
//             }
//
//         #endregion
//         
//         #region Create Manager Account
//
//             var userManagerManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//             var managerUser = new ApplicationUser { FirstName = "Primary", LastName = "Manager", UserName = "manager@domain.com", Email = "manager@domain.com" };
//
//             var managerExists = await userManagerManager.Users.AnyAsync(u => u.Email == managerUser.Email);
//             if (!managerExists)
//             {
//                 var result = await userManagerManager.CreateAsync(managerUser, "BytMig123!");
//                 if (result.Succeeded)
//                     await userManagerManager.AddToRoleAsync(managerUser, "Manager");
//             }
//
//         #endregion
//         
//         #region Create User Account
//
//             var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//             var user = new ApplicationUser { FirstName = "Primary", LastName = "User", UserName = "user@domain.com", Email = "user@domain.com" };
//
//             var userExists = await userManager.Users.AnyAsync(u => u.Email == user.Email);
//             if (!userExists)
//             {
//                 var result = await userManager.CreateAsync(user, "BytMig123!");
//                 if (result.Succeeded)
//                     await userManager.AddToRoleAsync(user, "User");
//             }
//
//         #endregion
//     }
//
// #endregion

app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Overview}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();