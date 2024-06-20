using System.Net;

namespace PaymentCheckApi.Service.Application.Shared;
public abstract class ApiResponse
{
	public static readonly string SuccessfulMessage = "Transaction Successful";
	public static readonly string ErrorMessage = "System Error";
	public ApiResponse(bool status, HttpStatusCode resultCode, string message, string token, object data)
	{
		Status = status;
		ResultCode = resultCode;
		Message = message;
		Token = token;
		Data = data;
	}

	public bool Status { get; set; }
	public HttpStatusCode ResultCode { get; set; }
	public string Message { get; set; }
	public string Token { get; set; }
	public object Data { get; set; }
}

public class SuccessfulResponse : ApiResponse
{
	public SuccessfulResponse(string message = "") : base(true, HttpStatusCode.OK, string.IsNullOrEmpty(message) ? SuccessfulMessage : message, string.Empty, null)
	{
	}

	public SuccessfulResponse(object data) : base(true, HttpStatusCode.OK, SuccessfulMessage, string.Empty, data)
	{
	}
	public SuccessfulResponse(string message, object data) : base(true, HttpStatusCode.OK, message, string.Empty, data)
	{
	}
}

public class ErrorResponse : ApiResponse
{
	public ErrorResponse(string message = "", HttpStatusCode resultCode = HttpStatusCode.InternalServerError, object data = null) : base(false, resultCode, string.IsNullOrEmpty(message) ? ErrorMessage : message, string.Empty, data)
	{
	}

}
