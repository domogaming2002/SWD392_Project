using Microsoft.EntityFrameworkCore;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.BussinessLayer.Repository;
using SWD392_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SWD_ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectString")));

builder.Services.AddScoped(typeof(IDrugRepository), typeof(DrugRepository));
builder.Services.AddScoped(typeof(ICategoryDrugRepository), typeof(CategoryDrugRepository));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
