using PaymentCheckApi.Service.Database;

namespace PaymentCheckApi.Service.Application.BaseService;
public class BaseService<T>
{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IHttpContextAccessor _httpContextAccessor;

	public BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
	{
		_unitOfWork = unitOfWork;
		_httpContextAccessor = httpContextAccessor;
	}


}
