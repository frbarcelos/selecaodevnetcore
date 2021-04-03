using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            string url = "https://github.com/frbarcelos/selecaodevnetcore.git";
            return url;
        }
    }
}
