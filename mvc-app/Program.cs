using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc_app.Data;
using mvc_app.Services;
using mvc_app.DTOs; // Por si lo llegás a necesitar más adelante.


var builder = WebApplication.CreateBuilder(args);

// ✅ Cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// ✅ Registrar el contexto de la base de datos con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ Configurar Identity con cuenta confirmada obligatoria
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Habilitar controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

// ✅ Habilitar Razor Pages para usar /Identity/Account/Register, Login, etc.
builder.Services.AddRazorPages();

var app = builder.Build();

// ================== Middleware ==================

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // muestra errores de migración en desarrollo
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // fuerza HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ✅ importante: habilita login/logout
app.UseAuthorization();

// ✅ Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ Razor Pages (para Identity UI)
app.MapRazorPages();

app.Run();
