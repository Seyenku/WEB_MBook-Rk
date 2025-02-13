using MBook_Rk;
using MBook_Rk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Добавление подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление Identity с использованием кастомных классов
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Регистрация кастомного RoleManager
builder.Services.AddScoped<RoleManager<ApplicationRole>>();
builder.Services.AddScoped<CustomRoleManager>();

// Регистрация кастомного UserManager
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<CustomUserManager>();

// Конфигурация куки для аутентификации
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Добавление других сервисов
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Создание миграций и обновление базы данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    // Применение миграций
    context.Database.Migrate();
    // Инициализация ролей после настройки всех сервисов
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