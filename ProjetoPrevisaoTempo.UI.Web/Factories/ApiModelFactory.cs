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

        private string ApIBaseUrl => _appSettings.BaseUrl ?? string.Empty;

        public RestClient GetClientAsync()
        {
            return new RestClient(ApIBaseUrl);
        }
    }
}
