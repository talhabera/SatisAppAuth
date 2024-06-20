namespace PaymentCheckApi.Service.Domain;
public abstract class BaseClass : BaseEntity
{
	public long CreateId { get; set; }
	public DateTime CreateDate { get; set; } = DateTime.Now;
	public long? EditId { get; set; }
	public DateTime? EditDate { get; set; }
	public long? DeleteId { get; set; }
	public DateTime? DeleteDate { get; set; }

}
