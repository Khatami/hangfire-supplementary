using Hangfire;
using Scheduling.Hangfire.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfireScheduleServices(builder.Configuration.GetConnectionString("SqlServerConnectionString")!, "test");

var app = builder.Build();

app.UseJobsDashboard(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();