using PaymentCheckApi.Service.Database.BaseRepository;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;

namespace PaymentCheckApi.Service.Database.Repository;

public interface ICustomerRepository : IBaseRepository<Customer>
{
}
