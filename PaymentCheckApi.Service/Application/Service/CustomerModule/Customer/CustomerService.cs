using PaymentCheckApi.Service.Application.BaseService;
using PaymentCheckApi.Service.Application.Shared;
using PaymentCheckApi.Service.Database;
using PaymentCheckApi.Service.Database.Repository;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Application.Service
{
	public class CustomerService : BaseService<Customer>, ICustomerService
	{
		private readonly ICustomerFactory _customerFactory;
		private readonly ICustomerRepository _customerRepository;
		public CustomerService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ICustomerFactory customerFactory, ICustomerRepository customerRepository) : base(unitOfWork, httpContextAccessor)
		{
			_customerFactory = customerFactory;
			_customerRepository = customerRepository;
		}

		public async Task<ApiResponse> AddCustomer(AddCustomerModel model)
		{
			try
			{
				var customer = _customerFactory.AddCustomerMapping(model);
				await _customerRepository.AddAsync(customer);
				await _unitOfWork.SaveChangesAsync();

				return new SuccessfulResponse(customer.Id);
			}
			catch (Exception exp)
			{
				throw new Exception(exp.Message);
			}
		}

		public Task<ApiResponse> DeleteCustomer(Guid customerId)
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponse> GetAllCustomers()
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponse> GetCustomerById(Guid customerId)
		{
			throw new NotImplementedException();
		}
	}
}
