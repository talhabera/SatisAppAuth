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
			var response = await _customerService.AddCustomer(model);

			return Ok(response);
		}


	}
}
