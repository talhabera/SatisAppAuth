using Microsoft.EntityFrameworkCore;

namespace PaymentCheckApi.Service.Database;

public sealed class Context : DbContext
{
	public Context(DbContextOptions options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Customer;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}

