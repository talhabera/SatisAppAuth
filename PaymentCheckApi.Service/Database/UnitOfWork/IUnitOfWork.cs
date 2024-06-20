namespace PaymentCheckApi.Service.Database;
	public interface IUnitOfWork
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
		Context GetContext();
	}

