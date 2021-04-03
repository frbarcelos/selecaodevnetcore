using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetornaTaxaController : Controller
    {
        [HttpGet]
        public double Get()
        {
            Taxa taxaAtual = BuscaTaxa();
            return taxaAtual.Valor;
        }

        private Taxa BuscaTaxa()
        {
            Taxa taxa = new Taxa();
            taxa.Valor = 0.01;
            return taxa;
        }
    }
}
