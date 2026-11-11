 
using LinqToDB;
using LinqToDB.AspNet;
using Infrastructure.Data;
using Infrastructure.Entities;
using Service;
using Microsoft.Extensions.DependencyInjection;

using NSwag.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Register Controllers and OpenAPI/Swagger
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontend", policy => {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

// Register linq2db Context
builder.Services.AddLinqToDBContext<AppDataConnection>((provider, options) =>
    options.UseSQLite(builder.Configuration.GetConnectionString("Default") ?? "Data Source=app.db"));




// Register Service Layer in DI Container
builder.Services.AddScoped<UserService>();

builder.WebHost.UseUrls("http://localhost:5000");

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDataConnection>();
db.CreateTable<User>(tableOptions: TableOptions.CreateIfNotExists);
db.CreateTable<Admin>(tableOptions: TableOptions.CreateIfNotExists);
db.CreateTable<HolidayRequest>(tableOptions: TableOptions.CreateIfNotExists);



var users = db.Users().ToList();
foreach (var u in users)
{
    db.Delete(u);
}

    
    
var admins = db.Admins().ToList();
foreach (var a in admins)
{
    db.Delete(a);
}
    
var holidayrequests = db.HolidayRequests().ToList();
foreach (var h in holidayrequests)
{
    db.Delete(h);
}


if (!db.Users().Any())
{
    db.Insert(new User()
    {
        Id = Guid.NewGuid().ToString(),
        Name = "James",
        PasswordHash = "",
        Email = "user@gmail.com"

    });


    db.Insert(new User()
    {
        Id = Guid.NewGuid().ToString(),
        Name = "Michael",
        PasswordHash = "",
        Email = "user@gmail.com"

    });

    db.Insert(new User()
    {
        Id = Guid.NewGuid().ToString(),
        Name = "Henry",
        PasswordHash = "",
        Email = "User@gmail.com"

    });
}


if (!db.Admins().Any())
{
    db.Insert(new Admin()
    {
        Id = Guid.NewGuid().ToString(),
        Name = "Xenia",
        PasswordHash = "",
        Email = "Admin@gmail.com"

    });
}


var james = db.Users()
    .FirstOrDefault(u => u.Name == "James");

if (!db.HolidayRequests().Any())
{
    db.Insert(new HolidayRequest()
    {
        
        Id = Guid.NewGuid().ToString(),
        UserId = james.Id,
        StartDate = new DateTime(2026, 11, 11),
        EndDate = new DateTime(2026, 11, 14),
        HolidayAccount = "a",
        RequestedDays = 3,
        RequestedHours = 72,
        Status = "Pending",
        CreatedAtUtc = new DateTime(2026, 9, 13)
    });
}

app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();

app.Run();
