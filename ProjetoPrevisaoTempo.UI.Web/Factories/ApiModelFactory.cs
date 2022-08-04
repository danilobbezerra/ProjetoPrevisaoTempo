using RestSharp;

namespace ProjetoPrevisaoTempo.UI.Web.Factories
{
    public class ApiModelFactory : IApiModelFactory
    {
        private readonly AppSettings _appSettings;

        public ApiModelFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        private string ApIBaseUrl => _appSettings.PrevisaoTempoApi.BaseUrl;

        public async Task<RestClient> GetClientAsync()
        {

            var client = new RestClient(ApIBaseUrl);

            return client;
        }
    }
}
