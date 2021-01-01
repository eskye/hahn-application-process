namespace Hahn.ApplicatonProcess.December2020.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using ViewModels;

    public interface IValidateCountryName
    {
        Task<bool> CheckIfCountryIsValid(string countryName, CancellationToken cancellationToken);
    }
    public class ValidateCountryName : IValidateCountryName
    {
        private readonly HttpClient _http;

        public ValidateCountryName(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CheckIfCountryIsValid(string countryName, CancellationToken token)
        {
            var requestUri = $"rest/v2/name/{countryName}?fullText=true";

            var response = await _http.GetFromJsonAsync<List<RestCountryResponse>>(requestUri, token);
            return response != null;
        }
    }
}
