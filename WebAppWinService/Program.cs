using Microsoft.Extensions.Hosting.WindowsServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Check if the app is running as a Windows Service
// TODO: Register windows service 'sc create "MyServiceName" binPath= "<path-to-your-app>\WebAppWinService.exe"' or 'New-Service -Name "MyServiceName" -BinaryPathName "<path-to-your-app>\WebAppWinService.exe"'
if (WindowsServiceHelpers.IsWindowsService())
{
    builder.Host.UseWindowsService();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
