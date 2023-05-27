using Hangfire;
using Scheduling.Hangfire.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfireScheduleServices(builder.Configuration.GetConnectionString("SqlServerConnectionString")!, "test");

builder.Services.AddTransient<ISyncGroupedProductService, SyncGroupedProductService>();

var app = builder.Build();

app.UseJobsDashboard(builder.Configuration);

RecurringJob.AddOrUpdate<ISyncGroupedProductService>(
	services => services.Sync(), "*/20 * * * *", TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time"));

app.MapGet("/", () => "Hello World!");

app.Run();