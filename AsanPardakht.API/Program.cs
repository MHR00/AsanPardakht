using AsanPardakht.Data.DbAccess;
using AsanPardakht.Services;
using AsanPardakht.Services.Interface;
using AsanPardakht.Services.Services.Jwt;
using AsanPardakht.Services.Services.Users;
using AsanPardakht.WebFramework.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IRegisterUserService, RegisterUserService>();
builder.Services.AddSingleton<ILoginUserService, LoginUserService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddJwtAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
