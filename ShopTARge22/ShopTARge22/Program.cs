global using ShopTARge22.ApplicationServices.Services;
global using ShopTARge22.Core.Dto.EmailDtos;
using ShopTARge22.Data;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.ServiceInterface;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
builder.Services.AddScoped<IKindergartensServices, KindergartensServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
builder.Services.AddScoped<ICocktailServices, CocktailServices>();
builder.Services.AddScoped<IAccuWeatherServices, AccuWeatherServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();



builder.Services.AddDbContext<ShopTARge22Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider
    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();