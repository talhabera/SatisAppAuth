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
        public async Task<IActionResult> ReduceCountOfDevices(GooglePlayAccountModel model)
        {
            var response = await _customerService.ReduceCountOfDeviceCustomerAsync(model.GooglePlayAccount);

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("IncreaseCountOfDevices")]
        public async Task<IActionResult> IncreaseCountOfDevices(GooglePlayAccountModel model)
        {
            var response = await _customerService.IncreaseCountOfDeviceCustomerAsync(model.GooglePlayAccount);

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("GetCountOfDevices")]
        public async Task<IActionResult> GetCountOfDevices(GooglePlayAccountModel model)
        {
            var response = await _customerService.GetCountOfDeviceCustomerAsync(model.GooglePlayAccount);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SetAsUnSubscribed")]
        public async Task<IActionResult> SetAsUnSubscribed(GooglePlayAccountModel model)
        {
            var response = await _customerService.SetAsUnSubscribedAsync(model.GooglePlayAccount);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SetAsSubscribed")]
        public async Task<IActionResult> SetAsSubscribed(GooglePlayAccountModel model)
        {
            var response = await _customerService.SetAsSubscribedAsync(model.GooglePlayAccount);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetIsSubscribed")]
        public async Task<IActionResult> GetIsSubscribed(GooglePlayAccountModel model)
        {
            var response = await _customerService.GetIsSubscribedAsync(model.GooglePlayAccount);

            return Ok(response);
        }


    }
}
