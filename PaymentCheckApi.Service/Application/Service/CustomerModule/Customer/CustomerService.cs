using Microsoft.EntityFrameworkCore;
using PaymentCheckApi.Service.Application.BaseService;
using PaymentCheckApi.Service.Application.Shared;
using PaymentCheckApi.Service.Database;
using PaymentCheckApi.Service.Database.Repository;
using PaymentCheckApi.Service.Domain.Models.CustomerModule;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Application.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ICustomerFactory customerFactory, ICustomerRepository customerRepository) : base(unitOfWork, httpContextAccessor)
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse> AddCustomerAsync(AddCustomerModel model)
        {
            try
            {
                var customer = _customerFactory.AddCustomerMapping(model);
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessfulResponse(customer.Id);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public async Task<ApiResponse> DeleteCustomerAsync(string customerGooglePlayAccount)
        {
            try
            {
                var customer = await _customerRepository.Queryable.FirstOrDefaultAsync(s => s.GooglePlayAccount == customerGooglePlayAccount);
                await _customerRepository.DeleteAsync(customer.Id);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessfulResponse(customer.Id);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public async Task<ApiResponse> EditCustomerAsync(EditCustomerModel model)
        {
            try
            {
                var customer = _customerFactory.EditCustomerMapping(model);
                await _customerRepository.UpdateAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessfulResponse(customer.Id);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public async Task<ApiResponse> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerRepository.Queryable.ToListAsync();

                return new SuccessfulResponse(customers);

            }
            catch (Exception exp)
            {


                throw new Exception(exp.Message);

            }
        }

        public async Task<ApiResponse> GetCountOfDeviceCustomerAsync(string customerGooglePlayAccount)
        {
            try
            {
                var customer = await _customerRepository.Queryable.FirstOrDefaultAsync(s => s.GooglePlayAccount == customerGooglePlayAccount);
               
                return new SuccessfulResponse(customer.CountOfConnectedDevices);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public async Task<ApiResponse> GetCustomerByGooglePlayAccountAsync(string customerGooglePlayAccount)
        {
            try
            {
                var customer = await _customerRepository.Queryable.FirstOrDefaultAsync(s => s.GooglePlayAccount == customerGooglePlayAccount);

                return new SuccessfulResponse(customer);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public async Task<ApiResponse> IncreaseCountOfDeviceCustomerAsync(string customerGooglePlayAccount)
        {
            try
            {
                var customer = await _customerRepository.Queryable.FirstOrDefaultAsync(s => s.GooglePlayAccount == customerGooglePlayAccount);
                customer.CountOfConnectedDevices = customer.CountOfConnectedDevices + 1;
                await _customerRepository.UpdateAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessfulResponse(customer.Id);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public async Task<ApiResponse> ReduceCountOfDeviceCustomerAsync(string customerGooglePlayAccount)
        {
            try
            {

                var customer = await _customerRepository.Queryable.FirstOrDefaultAsync(s => s.GooglePlayAccount == customerGooglePlayAccount);

                if (!(customer.CountOfConnectedDevices >= 0))
                    return new ErrorResponse("CountOfDevice is already 0");

                customer.CountOfConnectedDevices = customer.CountOfConnectedDevices - 1;
                await _customerRepository.UpdateAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessfulResponse(customer.Id);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
