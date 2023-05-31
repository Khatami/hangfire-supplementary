using Scheduling.Application;
using Scheduling.Infrastructure.Hangfire.Extensions;
using Scheduling.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.RegisterApplicationServices();
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.AddHangfireScheduleServices(builder.Configuration.GetConnectionString("SqlServerConnectionString")!, "scheduling_hangfire");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseJobsDashboard(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();