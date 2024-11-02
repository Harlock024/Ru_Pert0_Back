using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using ru_pert0_back.api.Context;
using ru_pert0_back.api.Models;
using Task = ru_pert0_back.api.Models.Task;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Ru_Pert0_Back Project");
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    var user = new User { Username = "johndoe", Password = "hashedPassword", Email = "john@example.com" };
    context.Users.Add(user);
    context.SaveChanges();
    var project = new Project { Name = "Project with Stages", UserId = user.Id, };
    context.Projects.Add(project);
    context.SaveChanges();
    
    var task = new Task
    {
        name = "Project with Stages",
        Description = "Task Description",
        Duration = 5,
        OptimisticTime = 3,
        MostLikelyTime = 5,
        PessimisticTime = 8
    };
    var task2 = new Task
    {
        name = "Project with Stages2",
        Description = "Task Description2",
        Duration = 5,
        OptimisticTime = 3,
        MostLikelyTime = 5,
        PessimisticTime = 8
    };
    context.Tasks.Add(task);
    context.Tasks.Add(task2);
    context.SaveChanges();
    var rootNode = new Node { Name = "CEO", ProjectId = project.Id, TaskId = task.Id,};
    var taskNode = new Node { Name = "manager", ProjectId = project.Id, TaskId = task2.Id,};
    context.Nodes.Add(rootNode);
    context.Nodes.Add(taskNode);
    context.SaveChanges();
    var pertEstimate = task.CalculatePERT();
    Console.WriteLine($"Estimated PERT Duration: {pertEstimate}");
}
app.Run();
