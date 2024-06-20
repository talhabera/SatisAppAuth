using PaymentCheckApi.Service.Domain.Enum;

namespace PaymentCheckApi.Service.Domain;

public abstract class BaseEntity
{
	public int Id { get; set; }
	public StatusEnum Status { get; set; }

}
