using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2
{
    public class CalculaJuros
    {
        private decimal? _taxa;
        private decimal _valorInicial;
        private int _meses;

        public CalculaJuros(decimal valorInicial, int meses, decimal? taxa)
        {
            _valorInicial = valorInicial;
            _meses = meses;
            _taxa = taxa;
        }

        public async Task<string> CalculaAsync()
        {
            int i;
            decimal valorCalculado = _valorInicial;

            if (!_taxa.HasValue)
            {
                _taxa = await BuscaTaxaAsync();
            }

            for (i = 0; i < _meses; i++)
            {
                valorCalculado *= (1 + (decimal)_taxa);
            }
            var valorFinal = Math.Truncate(100 * valorCalculado) / 100;
            return valorFinal.ToString("N2", new CultureInfo("pt-BR"));
        }

        private async Task<decimal> BuscaTaxaAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:54340/retornataxa");
            return Decimal.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}
