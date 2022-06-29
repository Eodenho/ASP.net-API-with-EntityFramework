using PostsWebAPI.DataDB;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddCors(options => { options.AddPolicy("ClientPermission", policy => { policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true).AllowCredentials(); }); });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbTaskContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", c =>
{
    c.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();
}));

var app = builder.Build();
app.UseCors("ClientPermission");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
