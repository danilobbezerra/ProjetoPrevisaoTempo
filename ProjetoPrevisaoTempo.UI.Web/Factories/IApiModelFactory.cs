using RestSharp;

namespace ProjetoPrevisaoTempo.UI.Web.Factories
{
    public interface IApiModelFactory
    {
        RestClient GetClientAsync();
    }
}
