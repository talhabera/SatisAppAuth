using DotNetCore.Repositories;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.Dynamic.Core;
using PaymentCheckApi.Service.Database.BaseRepository;
using PaymentCheckApi.Service.Domain.Enum;
using PaymentCheckApi.Service.Domain;

namespace PaymentCheckApi.Service.Database.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T>, ICommandRepository<T>, IQueryRepository<T> where T : class
{
	public readonly ICommandRepository<T> _commandRepository;

	public readonly IQueryRepository<T> _queryRepository;
	public IQueryable<T> Queryable => _queryRepository.Queryable.Where("Status!=" + ((int)StatusEnum.Deleted).ToString());
	public BaseRepository(ICommandRepository<T> commandRepository, IQueryRepository<T> queryRepository)
	{
		_commandRepository = commandRepository;
		_queryRepository = queryRepository;
	}

	public virtual void Add(T item)
	{
		_commandRepository.Add(item);
	}

	public virtual Task AddAsync(T item)
	{
		return _commandRepository.AddAsync(item);
	}

	public virtual Task RemoveAsync(T item)
	{
		PropertyInfo status = item.GetType().GetProperty(nameof(BaseClass.Status));
		PropertyInfo deleteDate = item.GetType().GetProperty(nameof(BaseClass.DeleteDate));
		status.SetValue(item, StatusEnum.Deleted);
		deleteDate.SetValue(item, DateTime.Now);
		return _commandRepository.UpdateAsync(item);
	}

	public virtual Task RemoveRangeAsync(IEnumerable<T> items)
	{
		foreach (var item in items)
		{
			PropertyInfo status = item.GetType().GetProperty(nameof(BaseClass.Status));
			PropertyInfo deleteDate = item.GetType().GetProperty(nameof(BaseClass.DeleteDate));
			status.SetValue(item, StatusEnum.Deleted);
			deleteDate.SetValue(item, DateTime.Now);
		}

		return _commandRepository.UpdateRangeAsync(items);
	}

	public virtual void RemoveRange(IEnumerable<T> items)
	{
		foreach (var item in items)
		{
			PropertyInfo status = item.GetType().GetProperty(nameof(BaseClass.Status));
			PropertyInfo deleteDate = item.GetType().GetProperty(nameof(BaseClass.DeleteDate));
			status.SetValue(item, StatusEnum.Deleted);
			deleteDate.SetValue(item, DateTime.Now);
		}

		_commandRepository.UpdateRange(items);
	}

	public virtual void AddRange(IEnumerable<T> items)
	{
		_commandRepository.AddRange(items);
	}

	public virtual Task AddRangeAsync(IEnumerable<T> items)
	{
		return _commandRepository.AddRangeAsync(items);
	}

	public virtual bool Any()
	{
		return _queryRepository.Any();
	}

	public virtual bool Any(Expression<Func<T, bool>> where)
	{
		return _queryRepository.Any(where);
	}

	public virtual Task<bool> AnyAsync()
	{
		return _queryRepository.AnyAsync();
	}

	public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> where)
	{
		return _queryRepository.AnyAsync(where);
	}

	public virtual long Count()
	{
		return _queryRepository.Count();
	}

	public virtual long Count(Expression<Func<T, bool>> where)
	{
		return _queryRepository.Count(where);
	}

	public virtual Task<long> CountAsync()
	{
		return _queryRepository.CountAsync();
	}

	public virtual Task<long> CountAsync(Expression<Func<T, bool>> where)
	{
		return _queryRepository.CountAsync(where);
	}

	public virtual void Delete(object key)
	{
		_commandRepository.Delete(key);
	}

	public virtual void Delete(Expression<Func<T, bool>> where)
	{
		_commandRepository.Delete(where);
	}

	public virtual Task DeleteAsync(object key)
	{
		return _commandRepository.DeleteAsync(key);
	}

	public virtual Task DeleteAsync(Expression<Func<T, bool>> where)
	{
		return _commandRepository.DeleteAsync(where);
	}

	public virtual T Get(object key)
	{
		return _queryRepository.Get(key);
	}

	public virtual Task<T> GetAsync(object key)
	{
		return _queryRepository.GetAsync(key);
	}

	public virtual IEnumerable<T> List()
	{
		return _queryRepository.List();
	}

	public virtual Task<IEnumerable<T>> ListAsync()
	{
		return _queryRepository.ListAsync();
	}

	public virtual void Update(T item)
	{
		_commandRepository.Update(item);
	}

	public virtual Task UpdateAsync(T item)
	{
		return _commandRepository.UpdateAsync(item);
	}

	public virtual void UpdatePartial(object item)
	{
		_commandRepository.UpdatePartial(item);
	}

	public virtual Task UpdatePartialAsync(object item)
	{
		return _commandRepository.UpdatePartialAsync(item);
	}

	public virtual void UpdateRange(IEnumerable<T> items)
	{
		_commandRepository.UpdateRange(items);
	}

	public virtual Task UpdateRangeAsync(IEnumerable<T> items)
	{
		return _commandRepository.UpdateRangeAsync(items);
	}

}

