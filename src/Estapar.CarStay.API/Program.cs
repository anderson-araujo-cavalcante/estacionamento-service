using Estapar.CarStay.API.Configuration;
using Estapar.CarStay.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddDbContext();
builder.Services.MapperConfig();
builder.Services.ResolveDependencies();
//builder.Services.AddIdentityConfiguration(builder.Configuration);

var app = builder.Build();

DatabaseManagementService.MigrationInitialisation(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
