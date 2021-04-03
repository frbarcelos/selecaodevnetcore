using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : Controller
    {
        public decimal? _taxa;

        [HttpGet]
        public async Task<string> GetAsync(decimal valorinicial, int meses)
        {
            var httpClient = new HttpClient();
            int i;
            decimal valorCalculado = valorinicial;

            if (!_taxa.HasValue)
            {
                var response = await httpClient.GetAsync("http://localhost:54340/retornataxa");
                _taxa = Decimal.Parse(await response.Content.ReadAsStringAsync());
            }
            
            for (i = 0; i < meses; i++)
            {
                valorCalculado *= (1 + (decimal)_taxa);
            }
            var valorFinal = Math.Truncate(100 * valorCalculado) / 100;
            return valorFinal.ToString("N2", new CultureInfo("pt-BR"));
        }
    }
}
