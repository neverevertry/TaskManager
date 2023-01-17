using Application.Interfaces;
using Application.Services;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string sql = "Data Source = SPEED; Integrated Security = True; Initial Catalog = Tracker; Connect Timeout = 30; Encrypt = False; " +
    "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDbContext>(optino => optino.UseSqlServer(sql));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserTaskService, UserTaskService>();
builder.Services.AddTransient<IUserRepository, EFUserRepository>();
builder.Services.AddTransient<IUserTaskRepository, EFUserTaskRepository>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICommentRepository, EFCommentsRepository>();
builder.Services.AddSession();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserTask}/{action=Index}/{id?}");

app.Run();

