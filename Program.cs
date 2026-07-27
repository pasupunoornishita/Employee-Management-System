using EmployeeManagementSystem.Demo;
using EmployeeManagementSystem.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEmployeeManagementServices(
    builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    DesignPatternDemoRunner.Run(app);
}

app.Run();
