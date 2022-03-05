namespace InfrastructureFE
{
    public static class UrlStrings
    {
        private const string _baseUrl = "http://localhost:5255/api";

        public const string ProizvodUrl = $"{_baseUrl}/Proizvod";
        public const string PonudaUrl = $"{_baseUrl}/Ponuda";
        public const string JavniPozivUrl = $"{_baseUrl}/JavniPoziv";
        public const string InformacijeOIsporuciUrl = $"{_baseUrl}/InformacijeOIsporuci";
        private const string BankaUrl = $"{_baseUrl}/Banka";
        private static readonly string PonudjacUrl = $"{_baseUrl}/Ponudjac";
    }
}
