using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PaymentCheckApi.Service.Database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
	public Context CreateDbContext(string[] args)
	{
		// Build configuration
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		// Get the connection string
		var connectionString = configuration.GetConnectionString("DefaultConnection");

		// Set up DbContext options
		var optionsBuilder = new DbContextOptionsBuilder<Context>();
		optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        });

		return new Context(optionsBuilder.Options);
	}
}


