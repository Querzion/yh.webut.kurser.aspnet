using Infrastructure.Contexts;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddScoped<ClientService>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();