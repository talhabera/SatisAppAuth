using PaymentCheckApi.Service.Application.Shared;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Application.Service;

	public interface ICustomerService
	{
	Task<ApiResponse> GetCustomerById(Guid customerId);
	Task<ApiResponse> GetAllCustomers();
	Task<ApiResponse> AddCustomer(AddCustomerModel model);
	//void UpdateCustomer(Guid customerId, UpdateCustomerModel model);
	Task<ApiResponse> DeleteCustomer(Guid customerId);
}

