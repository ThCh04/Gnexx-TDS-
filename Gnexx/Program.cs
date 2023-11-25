using Gnexx.Identity;
using Gnexx.Identity.Entities;
using Gnexx.Identity.Seeds;
using Gnexx.Middleware;
using Gnexx.Presistence.Shared;
using Gnexx.Repository;
using Gnexx.Repository.Context;
using Gnexx.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServiceLayer();
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddScoped<LoginFilter>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ValidateUserSession, ValidateUserSession>();
builder.Services.AddRepositoryfrastructure(builder.Configuration);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<GnexxDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Gnexx.Repository")
    ));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    try
    {
        var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
        var userRoles = service.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, userRoles);
        await DefaultCoachuser.SeedAsync(userManager, userRoles);
        await DefaultPlayerUser.SeedAsync(userManager, userRoles);
        
        //await DefaultPropertyType.SeedAsync(propertyType);
    }
    catch (Exception ex)
    {
        throw;
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.Run();
