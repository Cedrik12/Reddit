using Microsoft.EntityFrameworkCore;
using RedditButBetter.Models.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RedditContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
                    ServerVersion.Parse("10.6.7-mariadb"))
                    .UseLazyLoadingProxies();
}
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Connexion}/{action=Index}");

app.Run();
