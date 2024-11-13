using Auth.API.Entities;
using Auth.API.Extensions;
using Auth.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region CustomConfiguration

builder.Services.AddSwagger();
builder.Services.AddIdentity();
builder.Services.AddDbConnection(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureBinding(builder.Configuration);
builder.Services.AddDependencies();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}
//app.UseMiddleware<LoginMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
