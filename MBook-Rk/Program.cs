using MBook_Rk;
using MBook_Rk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// ���������� ����������� � ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� Identity � �������������� ��������� �������
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// ����������� ���������� RoleManager
builder.Services.AddScoped<RoleManager<ApplicationRole>>();
builder.Services.AddScoped<CustomRoleManager>();

// ����������� ���������� UserManager
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<CustomUserManager>();

// ������������ ���� ��� ��������������
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// ���������� ������ ��������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// �������� �������� � ���������� ���� ������
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    // ���������� ��������
    context.Database.Migrate();
    // ������������� ����� ����� ��������� ���� ��������
    await SeedRoles.InitializeRoles(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();