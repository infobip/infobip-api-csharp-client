using System.Net;

namespace Infobip.Api.Model.Exception
{
	public class InfobipApiException: System.Exception
	{
		public ApiErrorResponse ApiErrorResponse { get; }
		public HttpStatusCode StatusCode { get; }

	    public InfobipApiException(HttpStatusCode statusCode, ApiErrorResponse apiErrorResponse)
	        : base(apiErrorResponse.RequestError.ServiceException.Text)
	    {
			this.ApiErrorResponse = apiErrorResponse;
			this.StatusCode = statusCode;
	    }

	}
}