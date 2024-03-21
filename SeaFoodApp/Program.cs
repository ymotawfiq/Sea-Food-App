using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Repositories.CustomerDishesRepository;
using SeaFoodApp.Repositories.CustomerInfoRepository;
using SeaFoodApp.Repositories.CustomerRepository;
using SeaFoodApp.Repositories.DishRepository;
using SeaFoodApp.Repositories.EmployeeJobsRepository;
using SeaFoodApp.Repositories.EmployeeSalaryRepository;
using SeaFoodApp.Repositories.EmployeeService;
using SeaFoodApp.Repositories.JobService;
using SeaFoodApp.Repositories.TableOrderRepository;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>() //Line that can help you
  .AddEntityFrameworkStores<ApplicationDbContext>();
// defining identity core service

// to kill circular in json
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IJob, JobRepository>();
builder.Services.AddScoped<IEmployeeJobs, EmployeeJobsRepository>();
builder.Services.AddScoped<IEmployeeSalary, EmployeeSalaryRepository>();
builder.Services.AddScoped<IDish, DishRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<ICustomerInfo, CustomerInfoRepository>();
builder.Services.AddScoped<ICustomerDishes, CustomerDishesRepository>();
builder.Services.AddScoped<ITableOrder, TableOrderRepository>();


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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

