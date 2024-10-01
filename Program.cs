var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

// Middleware to enforce HTTPS.
app.UseHttpsRedirection();
// Middleware to serve static files (CSS, JS, images, etc.).
app.UseStaticFiles();

app.UseRouting();

// Authorization middleware (you can configure authentication later if needed).
app.UseAuthorization();

// Routing setup: defines the default controller and action to load on startup.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application.
app.Run();
