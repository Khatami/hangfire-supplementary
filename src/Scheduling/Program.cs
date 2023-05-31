using Scheduling.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddHangfireScheduleServices(builder.Configuration.GetConnectionString("SqlServerConnectionString")!, "scheduling_hangfire");
builder.Services.RegisterInfrastructureServices(builder.Configuration);

var app = builder.Build();

//app.UseJobsDashboard(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();