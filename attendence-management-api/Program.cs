using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementApi.Data;
using AttendenceManagementData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Db context registration
builder.Services.AddDbContext<AMSDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AMSDB")));

// Register the data provider
builder.Services.AddScoped<ITeacherDataProvider, TeacherDataProvider>();
builder.Services.AddScoped<IStudentDataProvider, StudentDataProvider>();

// Add services to the container.

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
