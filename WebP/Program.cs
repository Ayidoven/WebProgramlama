using WebP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL ba�lant�s� i�in DbContext kayd�
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC ve di�er servisleri ekleme
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP request pipeline yap�land�rmas�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // G�venlik i�in HSTS
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Statik dosyalar (CSS, JS, vb.) i�in

app.UseRouting();  // Routing yap�land�rmas�
app.UseAuthorization();  // Yetkilendirme middleware'�

// Controller routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulaman�n �al��mas�
app.Run();
