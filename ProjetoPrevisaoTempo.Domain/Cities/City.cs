using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Domain.Cities
{

    [ExcludeFromCodeCoverage]
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double Population { get; set; }
    }
}
