using System.Net.Http.Headers;

namespace Web
{
    public class EvaluationSystemWebRequestClient : WebRequestsClient<string>
    {
        public EvaluationSystemWebRequestClient() 
        {

        }

        /// <inheritdoc/>
        protected override AuthenticationHeaderValue CreateAuthenticationHeader(string authenticationArgs)
            => new("JWT token", authenticationArgs);
    }
}
