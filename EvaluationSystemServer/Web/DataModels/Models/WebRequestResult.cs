using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Headers;

namespace Web
{
    /// <summary>
    /// A web response from a call to get generic object data from a HTTP server
    /// </summary>
    public class WebRequestResult
    {
        #region Constants

        /// <summary>
        /// The default headers
        /// </summary>
        public static HttpResponseHeaders DefaultHeaders = new HttpResponseMessage().Headers;

        /// <summary>
        /// The error message for the exception
        /// </summary>
        public const string ExceptionMessage = $"The flag {nameof(IsSuccessful)} has the be true in order to access the {nameof(Result)}.";

        #endregion

        #region Private Members

        /// <summary>
        /// The member of the <see cref="Exception"/> property
        /// </summary>
        private Exception? mException;

        /// <summary>
        /// The member of the <see cref="Result"/>
        /// </summary>
        private object mResult = default!;

        #endregion

        #region Public Properties

        /// <summary>
        /// The exception that was thrown
        /// </summary>
        public Exception? Exception
        {
            get => mException ?? (IsSuccessful ? null : new Exception(ErrorMessage));

            set => mException = value;
        }

        /// <summary>
        /// If something failed, this is the error message.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <inheritdoc/>
        [MemberNotNullWhen(false, nameof(ErrorMessage), nameof(Exception))]
        public virtual bool IsSuccessful => ErrorMessage is null;

        /// <summary>
        /// The status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// All the response headers
        /// </summary>
        public HttpResponseHeaders Headers { get; set; } = DefaultHeaders;

        /// <summary>
        /// The raw server response body
        /// </summary>
        public string RawServerResponse { get; set; } = string.Empty;

        /// <summary>
        /// The actual server response as an object
        /// </summary>
        public object Result
        {
            get => IsSuccessful ? mResult : throw new InvalidOperationException(ExceptionMessage + Environment.NewLine + "Raw server response:" + Environment.NewLine + RawServerResponse);

            set => mResult = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public WebRequestResult() : base()
        {

        }

        /// <summary>
        /// Exception based constructor
        /// </summary>
        /// <param name="ex">The exception</param>
        public WebRequestResult(Exception ex) : base()
        {
            Exception = ex;
            ErrorMessage = ex.ToString();
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public override string ToString() => $"{nameof(StatusCode)}: {StatusCode}";

        /// <summary>
        /// Creates and returns a successful <see cref="WebRequestResult{T}"/> from the current object
        /// </summary>
        /// <typeparam name="T">The type of the result</typeparam>
        /// <param name="result">The result</param>
        /// <returns></returns>
        public WebRequestResult<T> ToSuccessfulWebRequestResult<T>(T result)
            => new()
            {
                Result = result,
                Exception = Exception,
                Headers = Headers,
                RawServerResponse = RawServerResponse,
                StatusCode = StatusCode,
            };

        /// <summary>
        /// Creates and returns an unsuccessful <see cref="WebRequestResult{T}"/> from the current object
        /// </summary>
        /// <typeparam name="T">The type of the result</typeparam>
        /// <param name="customErrorMessage">The custom error message</param>
        /// <returns></returns>
        public WebRequestResult<T> ToUnsuccessfulWebRequestResult<T>(string? customErrorMessage = null)
            => new()
            {
                ErrorMessage = customErrorMessage ?? ErrorMessage,
                Exception = Exception,
                Headers = Headers,
                RawServerResponse = RawServerResponse,
                StatusCode = StatusCode,
            };

        #endregion

        #region Operators

        /// <summary>
        /// Creates a <see cref="WebRequestResult"/> using the specified string as its error message
        /// </summary>
        /// <param name="s">The string</param>
        public static implicit operator WebRequestResult(string s) => new(new Exception(s));

        /// <summary>
        /// Creates a <see cref="Failable"/> using the message of the specified ex and its inner exceptions
        /// as its error message
        /// </summary>
        /// <param name="ex">The exception</param>
        public static implicit operator WebRequestResult(Exception ex) => new(ex);

        #endregion
    }

    /// <summary>
    /// A web response from a call to get specific data from a HTTP server
    /// </summary>
    /// <typeparam name="TResult">The type of data to deserialize the raw body into</typeparam>
    public class WebRequestResult<TResult> : WebRequestResult
    {
        #region Public Properties

        /// <summary>
        /// Casts the underlying object to the specified type
        /// </summary>
        public new TResult Result
        {
            get => (TResult)base.Result;
            set
            {
                if (value is not null)
                    base.Result = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public WebRequestResult() : base()
        {

        }

        /// <summary>
        /// Result based constructor
        /// </summary>
        /// <param name="result">The result</param>
        public WebRequestResult(TResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Exception based constructor
        /// </summary>
        /// <param name="ex">The exception</param>
        public WebRequestResult(Exception ex) : base(ex)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="WebRequestResult{T}"/> from the current object
        /// </summary>
        /// <typeparam name="T">The type of the failable</typeparam>
        /// <param name="valueConverter">The method that converts an instance of type <typeparamref name="TResult"/> to <typeparamref name="T"/></param>
        /// <returns></returns>
        public WebRequestResult<T> ToSuccessfulWebRequestResult<T>(Func<TResult, T> valueConverter)
            => new()
            {
                Result = valueConverter(Result),
                Headers = Headers,
                RawServerResponse = RawServerResponse,
                StatusCode = StatusCode,
            };

        #endregion

        #region Operators

        /// <summary>
        /// Creates a <see cref="WebRequestResult{TResult}"/> using the specified string as its error message
        /// </summary>
        /// <param name="s">The string</param>
        public static implicit operator WebRequestResult<TResult>(string s) => new(new Exception(s));

        /// <summary>
        /// Creates a <see cref="WebRequestResult{TResult}"/> using the message of the specified ex and its inner exceptions
        /// as its error message
        /// </summary>
        /// <param name="ex">The exception</param>
        public static implicit operator WebRequestResult<TResult>(Exception ex) => new(ex);

        /// <summary>
        /// Creates a <see cref="WebRequestResult{TResult}"/> using the specified result as its result
        /// </summary>
        /// <param name="result">The result</param>
        public static implicit operator WebRequestResult<TResult>(TResult result) => new(result);

        #endregion
    }
}
