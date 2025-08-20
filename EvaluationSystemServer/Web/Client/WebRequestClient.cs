using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Web
{
    /// <summary>
    /// Client that provides HTTP calls for sending and receiving information from an HTTP server
    /// </summary>
    /// <typeparam name="TAuthenticationArgs">
    /// The type of the authentication args
    /// NOTE: The authentication args determine the authentication scheme that will be used for the HTTP calls!
    /// </typeparam>
    public abstract class WebRequestsClient<TAuthenticationArgs>
        where TAuthenticationArgs : class
    {
        #region Constants

        private const string MediaTypeJson = "application/json";

        #endregion

        #region Protected Members

        protected readonly HttpClient mClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public WebRequestsClient()
        {
            mClient = new HttpClient();
        }

        #endregion

        #region Public Methods

        #region Non-Generic

        #region SEND

        /// <summary>
        /// SENDs a web request to the specified <paramref name="route"/> and returns a <see cref="HttpResponseMessage"/>
        /// </summary>
        /// <param name="route">The route</param>
        /// <param name="httpMethod">The type of the HTTP method</param>
        /// <param name="content">The content of the request</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> SendAsync(string route, HttpMethod httpMethod, object? content, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
        {
            try
            { 
                TimeSpan? timeOut = GetTimeOut();

                if (timeOut is not null)
                {
                    mClient.Timeout = timeOut.Value;
                }

                ConfigureClient(mClient);

                SetAuthorizationHeader(authenticationArgs);

                HttpRequestMessage httpRequest = new(httpMethod, new Uri(route));

                if (content is not null)
                {
                    httpRequest.Content = CreateHttpContent(content);
                }

                ConfigureHttpRequestMessage(httpRequest);

                HttpResponseMessage responseMessage = await mClient.SendAsync(httpRequest, cancellationToken);

                return responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                throw;
            }
        }

        #endregion

        #region POST

        /// <summary>
        /// POSTs a web request to the specified <paramref name="route"/> and returns a <see cref="HttpResponseMessage"/>
        /// </summary>
        /// <param name="route">The route</param>
        /// <param name="content">The content of the request</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PostAsync(string route, object? content, TAuthenticationArgs authenticationArgs, string methodName, CancellationToken cancellationToken = default)
            => SendAsync(route, HttpMethod.Post, content, authenticationArgs, cancellationToken);

        #endregion

        #region GET

        /// <summary>
        /// GETs a web request to the specified <paramref name="route"/> and returns a <see cref="HttpResponseMessage"/>
        /// </summary>
        /// <param name="route">The route</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> GetAsync(string route, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            => SendAsync(route, HttpMethod.Get, null, authenticationArgs, cancellationToken);

        #endregion

        #region PUT

        /// <summary>
        /// PUTs a web request to the specified <paramref name="route"/> and returns a <see cref="HttpResponseMessage"/>
        /// </summary>
        /// <param name="route">The route</param>
        /// <param name="content">The content of the request</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PutAsync(string route, object? content, TAuthenticationArgs authenticationArgs, string methodName, CancellationToken cancellationToken = default)
            => SendAsync(route, HttpMethod.Put, content, authenticationArgs, cancellationToken);

        #endregion

        #region DELETE

        /// <summary>
        /// DELETEs a web request to the specified <paramref name="route"/> and returns a <see cref="HttpResponseMessage"/>
        /// </summary>
        /// <param name="route">The route</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteAsync(string route, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            => SendAsync(route, HttpMethod.Delete, null, authenticationArgs, cancellationToken);

        #endregion

        #endregion

        #region Generic

        #region SEND

        /// <summary>
        /// SENDs a web request to the specified <paramref name="route"/> and returns a <see cref="ProviderResponse{T}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="route">The route</param>
        /// <param name="httpMethod">The type of the HTTP method</param>
        /// <param name="content">The content of the request</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<WebRequestResult<TResponse>> SendAsync<TResponse>(string route, HttpMethod httpMethod, object? content, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            where TResponse : class
        {
            HttpResponseMessage responseMessage;
            string responseContent;

            try
            {
                responseMessage = await SendAsync(route, httpMethod, content, authenticationArgs, cancellationToken);

                responseContent = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    return GetErrorResponse<TResponse>(responseMessage, responseContent);
                }
            }
            catch (Exception ex)
            {
                return new(ex);
            }

            if (string.IsNullOrEmpty(responseContent))
            {
                return new WebRequestResult<TResponse>()
                {
                    StatusCode = responseMessage.StatusCode
                };
            }

            TResponse? response;

            try
            {
                response = Deserialize<TResponse>(responseContent);
            }
            catch (Exception ex)
            {
                return new(ex);

                throw;
            }

            return new WebRequestResult<TResponse>()
            { 
                StatusCode = responseMessage.StatusCode,
                RawServerResponse = responseContent,
                Result = response ?? default!,
                Headers = responseMessage.Headers
            };
        }

        #endregion

        #region POST

        /// <summary>
        /// POSTs a web request to the specified <paramref name="route"/> and returns a <see cref="ProviderResponse{T}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="route">The route</param>
        /// <param name="content">The content of the request</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<WebRequestResult<TResponse>> PostAsync<TResponse>(string route, object? content, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            where TResponse : class
            => await SendAsync<TResponse>(route, HttpMethod.Post, content, authenticationArgs, cancellationToken);

        #endregion

        #region GET

        /// <summary>
        /// GETs a web request to the specified <paramref name="route"/> and returns a <see cref="ProviderResponse{T}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="route">The route</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<WebRequestResult<TResponse>> GetAsync<TResponse>(string route, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            where TResponse : class
            => await SendAsync<TResponse>(route, HttpMethod.Get, null, authenticationArgs, cancellationToken);

        #endregion

        #region PUT

        /// <summary>
        /// PUTs a web request to the specified <paramref name="route"/> and returns a <see cref="ProviderResponse{T}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="route">The route</param>
        /// <param name="content">The content of the request</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<WebRequestResult<TResponse>> PutAsync<TResponse>(string route, object? content, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            where TResponse : class
            => await SendAsync<TResponse>(route, HttpMethod.Put, content, authenticationArgs, cancellationToken);

        #endregion

        #region DELETE

        /// <summary>
        /// DELETEs a web request to the specified <paramref name="route"/> and returns a <see cref="ProviderResponse{T}"/>
        /// </summary>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="route">The route</param>
        /// <param name="authenticationArgs">The authentication</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<WebRequestResult<TResponse>> DeleteAsync<TResponse>(string route, TAuthenticationArgs authenticationArgs, CancellationToken cancellationToken = default)
            where TResponse : class
            => await SendAsync<TResponse>(route, HttpMethod.Delete, null, authenticationArgs, cancellationToken);

        #endregion

        #endregion

        #endregion

        #region Protected Methods

        /// <summary>
        /// Configures the specified <paramref name="client"/>
        /// </summary>
        /// <param name="client">The client</param>
        protected virtual void ConfigureClient(HttpClient client) { }

        /// <summary>
        /// Gets the media type header that is attached to the request before sending it
        /// </summary>
        /// <returns></returns>
        protected virtual string GetMediaType() => MediaTypeJson;

        /// <summary>
        /// Gets the encoding that is attached to the request before sending it
        /// </summary>
        /// <returns></returns>
        protected virtual Encoding GetEncoding() => Encoding.UTF8;

        /// <summary>
        /// Gets the time out that is attached to the request before sending it
        /// </summary>
        /// <returns></returns>
        protected virtual TimeSpan? GetTimeOut() => null;

        /// <summary>
        /// Creates and returns a <see cref="AuthenticationHeaderValue"/> using the
        /// specified <paramref name="authenticationArgs"/>
        /// </summary>
        /// <param name="authenticationArgs">The authentication arguments</param>
        /// <returns></returns>
        protected abstract AuthenticationHeaderValue CreateAuthenticationHeader(TAuthenticationArgs authenticationArgs);

        /// <summary>
        /// Handles the null authorization arguments
        /// </summary>
        protected virtual void HandleNullAuthenticationArgs() => mClient!.DefaultRequestHeaders.Authorization = null;

        /// <summary>
        /// Creates the <paramref name="content"/> for the body of the request
        /// </summary>
        /// <param name="content">The request body content</param>
        /// <returns></returns>
        protected virtual HttpContent CreateHttpContent(object content)
        {
            string jsonRequest = Serialize(content);

            StringContent httpContent = new(jsonRequest, GetEncoding(), GetMediaType());

            ConfigureStringContent(httpContent);

            return httpContent;
        }

        /// <summary>
        /// Configures the specified <paramref name="stringContent"/>
        /// </summary>
        /// <param name="stringContent">The content</param>
        protected virtual void ConfigureStringContent(StringContent stringContent) { }

        /// <summary>
        /// Configures the specified <paramref name="requestMessage"/>
        /// </summary>
        /// <param name="requestMessage">The request message</param>
        protected virtual void ConfigureHttpRequestMessage(HttpRequestMessage requestMessage) { }

        /// <summary>
        /// Serializes the specified <paramref name="obj"/> to a string
        /// before sending the request
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns></returns>
        protected virtual string Serialize(object obj)
            => JsonConvert.SerializeObject(obj);

        /// <summary>
        /// Deserializes the specified <paramref name="rawServerResponse"/> to the requested type
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize to</typeparam>
        /// <param name="rawServerResponse">The raw server response</param>
        /// <returns></returns>
        protected virtual TResponse? Deserialize<TResponse>(string rawServerResponse)
            => JsonConvert.DeserializeObject<TResponse>(rawServerResponse);

        /// <summary>
        /// Gets the <see cref="ProviderResponseError"/> from the specified <paramref name="responseMessage"/> and <paramref name="responseContent"/>
        /// </summary>
        /// <param name="responseMessage">The response message</param>
        /// <param name="responseContent">The response content</param>
        /// <returns></returns>
        protected virtual WebRequestResult<TResponse> GetErrorResponse<TResponse>(HttpResponseMessage responseMessage, string responseContent)
            => new() 
            {
                RawServerResponse = responseContent,
                StatusCode = responseMessage.StatusCode,
                ErrorMessage = "An error occurred!",
            };

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the specified <paramref name="authentication"/> if any to the <see cref="mClient"/>
        /// </summary>
        /// <param name="authentication">The authentication arguments</param>
        private void SetAuthorizationHeader(TAuthenticationArgs? authentication)
        {
            if (authentication is not null)
            {
                mClient!.DefaultRequestHeaders.Authorization = CreateAuthenticationHeader(authentication);

                return;
            }

            HandleNullAuthenticationArgs();
        }

        #endregion
    }
}
