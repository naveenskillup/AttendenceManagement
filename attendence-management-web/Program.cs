using AttendenceManagementWeb.ExternalServices;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) 
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ExternalApiClient>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AMSAPI") ?? "https://localhost:7154/api/");
    });

builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<ITeacherServices, TeacherServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
