using DotNetCore.Repositories;

namespace PaymentCheckApi.Service.Database.BaseRepository;

public interface IBaseRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class
{
	Task RemoveAsync(T item);
	Task RemoveRangeAsync(IEnumerable<T> items);
	void RemoveRange(IEnumerable<T> items);
}

