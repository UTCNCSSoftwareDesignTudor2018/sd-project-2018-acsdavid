using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public interface IBikePartRepository : IArticleRepository<BikePart>
    {
    }
}
