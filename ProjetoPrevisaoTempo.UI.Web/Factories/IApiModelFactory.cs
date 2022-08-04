using RestSharp;

namespace ProjetoPrevisaoTempo.UI.Web.Factories
{
    public interface IApiModelFactory
    {
        Task<RestClient> GetClientAsync();
    }
}
