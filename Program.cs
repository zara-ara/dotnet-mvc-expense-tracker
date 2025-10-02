var builder = WebApplication.CreateBuilder(args);

// Tambahkan service MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Wajib supaya bisa load AdminLTE (CSS, JS, images di wwwroot/adminlte)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Routing default
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
