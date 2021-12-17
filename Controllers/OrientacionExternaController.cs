using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using pnoa.Model;

namespace pnoa.Controllers
{
    public class OrientacionExternaController : Controller
    {
        IHostEnvironment _host;
        IServicioOrientacionesExternas _servicioOrientacionesExternas;
        public OrientacionExternaController(IServicioOrientacionesExternas servicioOrientacionesExternas, IHostEnvironment host )
        {
            _servicioOrientacionesExternas = servicioOrientacionesExternas;
            _host = host;
        }

        public IActionResult Index()
        {
            return Content(_host.ContentRootPath);
        }

        [Route("/orientacionexterna/{foto}")]
        public Task<OrientacionExterna> Index(string foto)
        {
            return _servicioOrientacionesExternas.ObtenOrientacionAsync(foto);
        }
    }
}