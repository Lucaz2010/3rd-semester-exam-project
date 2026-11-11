using Api;
using LinqToDB;
using LinqToDB.AspNet;
using Infrastructure.Data;
using Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Database connection string is missing.");
                       
                       
var options = new DataOptions<AppDbConnection>(
    new DataOptions().UsePostgreSQL(connectionString));
builder.Services.AddScoped<AppDbConnection>(_ =>
    new AppDbConnection(options));
    

builder.Services.ConfigureDomainServices(
    builder.Configuration);



builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddCors();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<MyExceptionHandler>();
builder.Services.AddScoped<HolidayRequestService>();

var app = builder.Build();


app.UseExceptionHandler();
app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(_=>true));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();





app.Run();

