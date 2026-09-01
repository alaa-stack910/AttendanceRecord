using AttendanceRecord;
using AttendanceRecord.Repo;
using AttendanceRecord.Repo.Implement;
using AttendanceRecord.Repo.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStudent,ImStudent>();
builder.Services.AddScoped<ISubject, ImSubject>();
builder.Services.AddScoped<IAttendance, ImAttendance>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppContexts>(v => v.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
