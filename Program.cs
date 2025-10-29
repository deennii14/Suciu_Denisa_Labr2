using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Suciu_Denisa_Labr2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<Suciu_Denisa_Labr2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Suciu_Denisa_Labr2Context")
        ?? throw new InvalidOperationException("Connection string 'Suciu_Denisa_Labr2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Suciu_Denisa_Labr2Context")
        ?? throw new InvalidOperationException("Connection string 'Suciu_Denisa_Labr2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
