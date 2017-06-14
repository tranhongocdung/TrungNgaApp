using System.Linq;
using System.Web.Mvc;
using MVCWeb.Core.Entities;
using MVCWeb.Core.Security;
using MVCWeb.Libraries;

namespace MVCWeb.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class DataSourceController : BaseController
    {
        // GET: DataSource
        public ActionResult Index()
        {
            return View();
        }

       
    }
}