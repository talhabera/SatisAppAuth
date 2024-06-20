using DotNetCore.EntityFrameworkCore;
using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using PaymentCheckApi.Service.Database.Repository;

namespace PaymentCheckApi.Service.Database.BaseRepository;

public abstract class BaseEFRepository<T> : BaseRepository<T> where T : class
{
	public BaseEFRepository(DbContext context)
		: base((ICommandRepository<T>)new EFCommandRepository<T>(context), (IQueryRepository<T>)new EFQueryRepository<T>(context)) { }
}

