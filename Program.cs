using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Labr2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Suciu_Denisa_Labr2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Suciu_Denisa_Labr2Context")
        ?? throw new InvalidOperationException("Connection string 'Suciu_Denisa_Labr2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIdentityContextConnection")
        ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContextConnection' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
});

var app = builder.Build();

async Task CreateDefaultUsersAndRolesAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
    if (adminUser == null)
    {
        var user = new IdentityUser
        {
            UserName = "admin@gmail.com",
            Email = "admin@gmail.com",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user, "Admin123!");
        await userManager.AddToRoleAsync(user, "Admin");
    }

    var normalUser = await userManager.FindByEmailAsync("ion.popescu@gmail.com");
    if (normalUser == null)
    {
        var user = new IdentityUser
        {
            UserName = "ion.popescu@gmail.com",
            Email = "ion.popescu@gmail.com",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user, "Parola123!");
        await userManager.AddToRoleAsync(user, "User");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

await CreateDefaultUsersAndRolesAsync(app);

app.Run();
