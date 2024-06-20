using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Application.Service;

	public interface ICustomerFactory
	{
		Customer AddCustomerMapping(AddCustomerModel model); 
		Customer EditCustomerMapping(EditCustomerModel model);
}

