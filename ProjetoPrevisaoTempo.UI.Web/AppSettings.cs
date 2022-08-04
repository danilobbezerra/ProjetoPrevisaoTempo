namespace ProjetoPrevisaoTempo.UI.Web
{
    public class AppSettings
    {
        public PrevisaoTempo? PrevisaoTempoApi { get; set; }


        public class PrevisaoTempo
        {
            public string BaseUrl { get; set; }
        }
    }
}
