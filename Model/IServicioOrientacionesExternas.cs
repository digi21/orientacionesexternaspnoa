using System.Threading.Tasks;

namespace pnoa.Model
{
    public interface IServicioOrientacionesExternas
    {
         Task<OrientacionExterna> ObtenOrientacionAsync(string foto);
    }
}