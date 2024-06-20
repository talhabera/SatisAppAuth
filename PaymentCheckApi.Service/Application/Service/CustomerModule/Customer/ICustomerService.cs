using PaymentCheckApi.Service.Application.Shared;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Application.Service;

	public interface ICustomerService
	{
	Task<ApiResponse> GetCustomerByGooglePlayAccountAsync(string customerGooglePlayAccount);
	Task<ApiResponse> GetAllCustomersAsync();
	Task<ApiResponse> AddCustomerAsync(AddCustomerModel model);
	//void UpdateCustomer(Guid customerId, UpdateCustomerModel model);
	Task<ApiResponse> DeleteCustomerAsync(string customerGooglePlayAccount);
	Task<ApiResponse> EditCustomerAsync(EditCustomerModel model);

    Task<ApiResponse> IncreaseCountOfDeviceCustomerAsync(string customerGooglePlayAccount);
    Task<ApiResponse> GetCountOfDeviceCustomerAsync(string customerGooglePlayAccount);
    Task<ApiResponse> ReduceCountOfDeviceCustomerAsync(string customerGooglePlayAccount);
}

