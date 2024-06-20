namespace PaymentCheckApi.Service.Database;

public class UnitOfWork : IUnitOfWork
{
	private readonly Context _context;
	public UnitOfWork(Context context)
	{
		_context = context;
	}

	public async void Dispose() => await _context.DisposeAsync();

	public int SaveChanges()
	{
		return _context.SaveChanges();
	}

	public Task<int> SaveChangesAsync()
	{
		return _context.SaveChangesAsync();
	}


	public Context GetContext()
	{
		return _context;
	}
}

