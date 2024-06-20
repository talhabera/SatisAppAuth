using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentCheckApi.Service.Application.Service;
using PaymentCheckApi.Service.Model.CustomerModule;

namespace PaymentCheckApi.Service.Controllers
{
	[ApiController]
	[Route("Customer")]
	public class CustomerApiController : ControllerBase
	{

		private readonly ILogger<CustomerApiController> _logger;
		private readonly ICustomerService _customerService;

		public CustomerApiController(ILogger<CustomerApiController> logger, ICustomerService customerService)
		{
			_logger = logger;
			_customerService = customerService;
		}


		[AllowAnonymous]
		[HttpPost]
		[Route("CreateCustomer")]
		public async Task<IActionResult> CreateCustomerAsync(AddCustomerModel model)
		{
			var response = await _customerService.AddCustomerAsync(model);

			return Ok(response);
		}

        [AllowAnonymous]
        [HttpPost]
        [Route("ReduceCountOfDevices")]
        public async Task<IActionResult> ReduceCountOfDevices(string customerGooglePlayAccount)
        {
            var response = await _customerService.ReduceCountOfDeviceCustomerAsync(customerGooglePlayAccount);

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("IncreaseCountOfDevices")]
        public async Task<IActionResult> IncreaseCountOfDevices(string customerGooglePlayAccount)
        {
            var response = await _customerService.IncreaseCountOfDeviceCustomerAsync(customerGooglePlayAccount);

            return Ok(response);
        }


    }
}
