namespace ProjetoPrevisaoTempo.UI.Web
{
    public class AppSettings
    {
        public AppSettings()
        {
            BaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
        }
        public string? BaseUrl { get; set; }
    }
}
