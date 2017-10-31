using System;
using System.Net;

namespace InfobipClient.infobip.api.model.error
{
	public class InfobipApiException: Exception
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