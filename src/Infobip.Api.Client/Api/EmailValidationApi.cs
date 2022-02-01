/*
 * Infobip Client API Libraries OpenAPI Specification
 * OpenAPI specification containing public endpoints supported in client API libraries.
 *
 * Contact: support@infobip.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.Client;
using ClientConfiguration = Infobip.Api.Client.Configuration;
using Infobip.Api.Client.Model;

namespace Infobip.Api.Client.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEmailValidationApiSync : IApiAccessor
    {
        #region Synchronous Operations

        /// <summary>
        ///     Validate email addresses
        /// </summary>
        /// <remarks>
        ///     Run validation to identify poor quality emails to clean up your recipient list.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <returns>EmailValidationResponse</returns>
        EmailValidationResponse ValidateEmailAddresses(EmailValidationRequest emailValidationRequest = default);

        /// <summary>
        ///     Validate email addresses
        /// </summary>
        /// <remarks>
        ///     Run validation to identify poor quality emails to clean up your recipient list.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <returns>ApiResponse of EmailValidationResponse</returns>
        ApiResponse<EmailValidationResponse> ValidateEmailAddressesWithHttpInfo(
            EmailValidationRequest emailValidationRequest = default);

        #endregion Synchronous Operations
    }

    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEmailValidationApiAsync : IApiAccessor
    {
        #region Asynchronous Operations

        /// <summary>
        ///     Validate email addresses
        /// </summary>
        /// <remarks>
        ///     Run validation to identify poor quality emails to clean up your recipient list.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EmailValidationResponse</returns>
        Task<EmailValidationResponse> ValidateEmailAddressesAsync(
            EmailValidationRequest emailValidationRequest = default,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Validate email addresses
        /// </summary>
        /// <remarks>
        ///     Run validation to identify poor quality emails to clean up your recipient list.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EmailValidationResponse)</returns>
        Task<ApiResponse<EmailValidationResponse>> ValidateEmailAddressesWithHttpInfoAsync(
            EmailValidationRequest emailValidationRequest = default,
            CancellationToken cancellationToken = default(CancellationToken));

        #endregion Asynchronous Operations
    }

    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEmailValidationApi : IEmailValidationApiSync, IEmailValidationApiAsync
    {
    }

    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class EmailValidationApi : IEmailValidationApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class.
        /// </summary>
        /// <returns></returns>
        public EmailValidationApi() : this((string)null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public EmailValidationApi(string basePath)
        {
            Configuration = ClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            ApiClient = new ApiClient(Configuration.BasePath);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class using Configuration object.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public EmailValidationApi(Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            Configuration = ClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            ApiClient = new ApiClient(Configuration.BasePath);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        ///     Some configuration settings will not be applied without passing an HttpClientHandler.
        ///     The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public EmailValidationApi(HttpClient client) : this(client, (string)null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        ///     Some configuration settings will not be applied without passing an HttpClientHandler.
        ///     The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public EmailValidationApi(HttpClient client, string basePath)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            Configuration = ClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            ApiClient = new ApiClient(client, Configuration.BasePath);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        ///     Some configuration settings will not be applied without passing an HttpClientHandler.
        ///     The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public EmailValidationApi(HttpClient client, Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (client == null) throw new ArgumentNullException(nameof(client));

            Configuration = ClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            ApiClient = new ApiClient(client, Configuration.BasePath);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public EmailValidationApi(HttpClient client, HttpClientHandler handler) : this(client, handler, (string)null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An instance of HttpClientHandler that is used by HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public EmailValidationApi(HttpClient client, HttpClientHandler handler, string basePath)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            Configuration = ClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            ApiClient = new ApiClient(client, handler, Configuration.BasePath);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An instance of HttpClientHandler that is used by HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public EmailValidationApi(HttpClient client, HttpClientHandler handler, Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            Configuration = ClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            ApiClient = new ApiClient(client, handler, Configuration.BasePath);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailValidationApi" /> class
        ///     using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmailValidationApi(ISynchronousClient client, IAsynchronousClient asyncClient,
            IReadableConfiguration configuration)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            AsynchronousClient = asyncClient ?? throw new ArgumentNullException(nameof(asyncClient));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ExceptionFactory = ClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Holds the ApiClient if created
        /// </summary>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        ///     The client for accessing this underlying API asynchronously.
        /// </summary>
        public IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        ///     The client for accessing this underlying API synchronously.
        /// </summary>
        public ISynchronousClient Client { get; set; }

        /// <summary>
        ///     Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return Configuration.BasePath;
        }

        /// <summary>
        ///     Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IReadableConfiguration Configuration { get; set; }

        /// <summary>
        ///     Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }

        /// <summary>
        ///     Validate email addresses Run validation to identify poor quality emails to clean up your recipient list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <returns>EmailValidationResponse</returns>
        public EmailValidationResponse ValidateEmailAddresses(EmailValidationRequest emailValidationRequest = default)
        {
            var localVarResponse = ValidateEmailAddressesWithHttpInfo(emailValidationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Validate email addresses Run validation to identify poor quality emails to clean up your recipient list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <returns>ApiResponse of EmailValidationResponse</returns>
        public ApiResponse<EmailValidationResponse> ValidateEmailAddressesWithHttpInfo(
            EmailValidationRequest emailValidationRequest = default)
        {
            var localVarRequestOptions = new RequestOptions();

            string[] contentTypes =
            {
                "application/json",
                "application/x-www-form-urlencoded"
            };

            // to determine the Accept header
            string[] accepts =
            {
                "application/json",
                "application/xml"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = emailValidationRequest;

            // authentication (APIKeyHeader) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
                if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
                    localVarRequestOptions.HeaderParameters.Add("Authorization",
                        Configuration.GetApiKeyWithPrefix("Authorization"));
            // authentication (Basic) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(Configuration.Username) || !string.IsNullOrEmpty(Configuration.Password))
                localVarRequestOptions.HeaderParameters.Add("Authorization",
                    "Basic " + ClientUtils.Base64Encode(Configuration.Username + ":" + Configuration.Password));
            // authentication (IBSSOTokenHeader) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
                if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
                    localVarRequestOptions.HeaderParameters.Add("Authorization",
                        Configuration.GetApiKeyWithPrefix("Authorization"));
            // authentication (OAuth2) required
            // oauth required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + Configuration.AccessToken);

            // make the HTTP request
            var localVarResponse =
                Client.Post<EmailValidationResponse>("/email/2/validation", localVarRequestOptions, Configuration);

            Exception exception = ExceptionFactory?.Invoke("ValidateEmailAddresses", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse;
        }

        /// <summary>
        ///     Validate email addresses Run validation to identify poor quality emails to clean up your recipient list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EmailValidationResponse</returns>
        public async Task<EmailValidationResponse> ValidateEmailAddressesAsync(
            EmailValidationRequest emailValidationRequest = default,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ApiResponse<EmailValidationResponse> localVarResponse =
                await ValidateEmailAddressesWithHttpInfoAsync(emailValidationRequest, cancellationToken)
                    .ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Validate email addresses Run validation to identify poor quality emails to clean up your recipient list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="emailValidationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EmailValidationResponse)</returns>
        public async Task<ApiResponse<EmailValidationResponse>> ValidateEmailAddressesWithHttpInfoAsync(
            EmailValidationRequest emailValidationRequest = default,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();

            string[] contentTypes =
            {
                "application/json",
                "application/x-www-form-urlencoded"
            };

            // to determine the Accept header
            string[] accepts =
            {
                "application/json",
                "application/xml"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = emailValidationRequest;

            // authentication (APIKeyHeader) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
                if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
                    localVarRequestOptions.HeaderParameters.Add("Authorization",
                        Configuration.GetApiKeyWithPrefix("Authorization"));
            // authentication (Basic) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(Configuration.Username) || !string.IsNullOrEmpty(Configuration.Password))
                localVarRequestOptions.HeaderParameters.Add("Authorization",
                    "Basic " + ClientUtils.Base64Encode(Configuration.Username + ":" + Configuration.Password));
            // authentication (IBSSOTokenHeader) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
                if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
                    localVarRequestOptions.HeaderParameters.Add("Authorization",
                        Configuration.GetApiKeyWithPrefix("Authorization"));
            // authentication (OAuth2) required
            // oauth required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + Configuration.AccessToken);

            // make the HTTP request

            var localVarResponse = await AsynchronousClient
                .PostAsync<EmailValidationResponse>("/email/2/validation", localVarRequestOptions, Configuration,
                    cancellationToken).ConfigureAwait(false);

            Exception exception = ExceptionFactory?.Invoke("ValidateEmailAddresses", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse;
        }

        /// <summary>
        ///     Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            ApiClient?.Dispose();
        }
    }
}