using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PaymentCheckApi.Service.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<Context>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("DefaultConnection"),
         sqlServerOptionsAction: sqlOptions =>
         {
             sqlOptions.EnableRetryOnFailure(
                 maxRetryCount: 5, // The maximum number of retry attempts
                 maxRetryDelay: TimeSpan.FromSeconds(30), // The maximum delay between retries
                 errorNumbersToAdd: null); // Additional SQL error numbers to add to the list of transient errors
         }));

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Scan(scan => scan
	.FromApplicationDependencies()
		.AddClasses(classes => classes.InNamespaces(
		"PaymentCheckApi.Service.Application.Service",
		"PaymentCheckApi.Service.Database.Repository"))
	.AsImplementedInterfaces()
	.WithScopedLifetime());

builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
