using WebP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL baðlantýsý için DbContext kaydý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC ve diðer servisleri ekleme
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP request pipeline yapýlandýrmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Güvenlik için HSTS
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Statik dosyalar (CSS, JS, vb.) için

app.UseRouting();  // Routing yapýlandýrmasý
app.UseAuthorization();  // Yetkilendirme middleware'ý

// Controller routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulamanýn çalýþmasý
app.Run();
