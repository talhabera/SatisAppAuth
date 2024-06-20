namespace PaymentCheckApi.Service.Model.CustomerModule;

public partial record AddCustomerModel : BaseModel
{
	public string GooglePlayAccount { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string PhoneNumber { get; set; }
}

