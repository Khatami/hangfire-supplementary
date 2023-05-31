using Scheduling.Infrastructure.Hangfire.Extensions;
using Scheduling.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.AddHangfireScheduleServices(builder.Configuration.GetConnectionString("SqlServerConnectionString")!, "scheduling_hangfire");

var app = builder.Build();

app.UseJobsDashboard(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();