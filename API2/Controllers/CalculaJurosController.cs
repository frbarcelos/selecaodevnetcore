using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : Controller
    {
        [HttpGet]
        public string Get(decimal valorInicial, int meses, decimal? taxa)
        {
            CalculaJuros calculaJuros = new CalculaJuros(valorInicial, meses, taxa);
            return calculaJuros.CalculaAsync().Result;
        }
    }
}
