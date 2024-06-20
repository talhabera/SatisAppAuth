using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentCheckApi.Service.Domain.Models.CustomerModule;

public class Customer : BaseClass
{
    public string GooglePlayAccount { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsSubscribed { get; set; } = false;
	public int CountOfConnectedDevices { get; set; } = 0;

}