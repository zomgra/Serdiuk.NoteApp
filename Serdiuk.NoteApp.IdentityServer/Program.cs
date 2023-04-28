using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.IdentityServer;
using Serdiuk.NoteApp.Infrastructure.Persistance.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddCors(b =>
{
    b.AddDefaultPolicy(d =>
    {
        d.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000", "https://localhost:7035");
    });
});


builder.Services.AddDbContext<AuthDbContext>(config =>
{
    config.UseInMemoryDatabase("MEMORY");
})
                .AddIdentity<IdentityUser, IdentityRole>(config =>
                { 
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();




builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources())
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources())
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes())
    .AddInMemoryClients(IdentityConfiguration.Clients())
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Auth/Login";
});

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

AuthDbContextSeed.Initialize(app.Services).GetAwaiter().GetResult();

app.Run();
