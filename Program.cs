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
builder.Services.AddTransient<IUserRepository, UserRepository>()
    .AddDbContext<SWD_ProjectContext>(opt =>
    builder.Configuration.GetConnectionString("DataConnectString"));

// Configure session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddScoped(typeof(IMedicineRepository), typeof(MedicineRepository));
builder.Services.AddScoped(typeof(ICategoryMedicineRepository), typeof(CategoryMedicineRepository));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// using session
app.UseSession();

// using middleware
app.UseMiddleware<AuthorizeMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
