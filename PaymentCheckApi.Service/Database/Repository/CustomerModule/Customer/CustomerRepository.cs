using Microsoft.EntityFrameworkCore;
using PaymentCheckApi.Service.Database.BaseRepository;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;

namespace PaymentCheckApi.Service.Database.Repository;

public class CustomerRepository : BaseEFRepository<Customer>, ICustomerRepository
{
	public CustomerRepository(Context context) : base(context)
	{
	}
}
