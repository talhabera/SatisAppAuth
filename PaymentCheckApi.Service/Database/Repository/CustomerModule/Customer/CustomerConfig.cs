using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Database.Shared;

namespace PaymentCheckApi.Service.Database.Repository;

	public class CustomerConfig : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable(nameof(Customer), DBConfig.SchemaName);
			builder.HasKey(s => s.Id);

			builder.Property(s => s.GooglePlayAccount).IsRequired();

		}
	}

