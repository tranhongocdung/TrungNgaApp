using System.Linq;
using System.Web.Mvc;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class DataSourceController : BaseController
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IPickUpLocationRepository _pickUpLocationRepository;
        public DataSourceController(
            IPassengerRepository passengerRepository,
            IPickUpLocationRepository pickUpLocationRepository
            )
        {
            _passengerRepository = passengerRepository;
            _pickUpLocationRepository = pickUpLocationRepository;
        }

        public ActionResult GetPassengerSuggestion(string query, int id = 0)
        {
            if (id != 0)
            {
                var item = _passengerRepository.TableNoTracking.First(o => o.Id == id);
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            var list =
                _passengerRepository.TableNoTracking.Where(
                    o => o.PassengerPhoneNo.Contains(query) || o.PassengerName.Contains(query)).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPickUpLocationSuggestion(string query, int id = 0)
        {
            if (id != 0)
            {
                var item = _pickUpLocationRepository.TableNoTracking.First(o => o.Id == id);
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            var list =
                _pickUpLocationRepository.TableNoTracking.Where(
                    o => o.Address.Contains(query)).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}