using AutoMapper;
using DotnetBackendAPI;
using DotnetBackendAPI.DB;
using DotnetBackendAPI.IServices;
using DotnetBackendAPI.Services;
using DotnetBackendAPI.UserInterfaces;
using DotnetBackendAPI.UserRepositories;
using Microsoft.EntityFrameworkCore;
    
var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")), ServiceLifetime.Scoped);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<UserInterface, UserRepository>();
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
