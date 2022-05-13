using ProjectManagementApp.Controllers;
using ProjectManagementApp.Data.Data;
using ProjectManagementApp.Data.Models;
using ProjectManagementApp.Data.Services;
using Task = ProjectManagementApp.Data.Models.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMvc()
    .AddControllersAsServices()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.MaxDepth = 6;
    });

builder.Services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddSingleton<IRepository<Project>, ProjectRepository>();
builder.Services.AddSingleton<IRepository<Task>, TaskRepository>();
builder.Services.AddSingleton<IRepository<History>, HistoryRepository>();

builder.Services.AddScoped<IService, TaskService>();
builder.Services.AddScoped(sp =>
    new TasksController(new TaskService(sp.GetService<IRepository<Task>>(), sp.GetService<IRepository<History>>())));

builder.Services.AddScoped<IService, HistoryService>();
builder.Services.AddScoped(sp =>
    new HistoriesController(new HistoryService(sp.GetService<IRepository<History>>())));

builder.Services.AddScoped<IService, ProjectService>();
builder.Services.AddScoped(sp =>
    new ProjectsController(new ProjectService(sp.GetService<IRepository<Project>>())));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
