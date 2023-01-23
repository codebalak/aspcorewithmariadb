using aspcoremariadb;
using aspcoremariadb.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

/*app.Run(async context =>
{
   // HttpContext.Session.SetString("mysess", "myvalue");
    await context.Response.WriteAsync("Hello world!");
    
});*/




/*builder.Services.AddDbContext<DatabaseContext>(options => options
                .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")));*/


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseSession();last  update
//app.UseCustomMiddleware();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

//app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Demo}/{action=AddBook}/{id?}");

app.Run();
