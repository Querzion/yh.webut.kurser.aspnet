var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();