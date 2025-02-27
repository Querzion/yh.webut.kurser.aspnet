var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Connection strings from the appsettings.json file,
// no rebuild required if the string is changed there.
// string serviceBus = builder.Configuration.GetConnectionString("ServiceBus")!;
// string connectionString = builder.Configuration.GetConnectionString("LocalDatabaseFile")!;
// builder.Services.AddDbContext<>();
// builder.Services.AddTransient<>();
// builder.Services.AddScoped<>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();