using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaymentCheckApi.Service.Model;

public partial record BaseModel
{
	public BaseModel()
	{
		PostInitialize();
	}

	public virtual void BindModel(ModelBindingContext bindingContext)
	{
	}

	protected virtual void PostInitialize()
	{
	}

}

