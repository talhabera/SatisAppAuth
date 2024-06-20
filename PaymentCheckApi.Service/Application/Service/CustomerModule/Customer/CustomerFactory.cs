using AutoMapper;
using PaymentCheckApi.Service.Application.Shared;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Application.Service;

public class CustomerFactory : ICustomerFactory
{
	public Customer AddCustomerMapping(AddCustomerModel model)
	{
		Action<IMapperConfigurationExpression> configExpression = cfg =>
		{
			cfg.CreateMap<AddCustomerModel, Customer>();
		};
		var customer = model.MappingByConfig<AddCustomerModel, Customer>(configExpression);
		return customer;
	}

    public Customer EditCustomerMapping(EditCustomerModel model)
    {
        Action<IMapperConfigurationExpression> configExpression = cfg =>
        {
            cfg.CreateMap<EditCustomerModel, Customer>();
        };
        var customer = model.MappingByConfig<EditCustomerModel, Customer>(configExpression);
        return customer;
    }
}

