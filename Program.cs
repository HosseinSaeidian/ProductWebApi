using Microsoft.EntityFrameworkCore;
using SessionNine.Application.Extention;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure;
using SessionNine.Infrastructure.Data.Core;
using SessionNine.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InjectServicesExtention(builder.Configuration);

var app = builder.Build();

app.UseApplicationMiddlewares(app.Environment);

// app.UseHttpsRedirection();
// app.UseAuthorization();
app.MapControllers();
app.Run();
