﻿using System.Linq;
using System.Web.Mvc;
using MVCWeb.AppDataLayer.Entities;
using MVCWeb.AppDataLayer.Security;
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

        public ActionResult GetProductName(string query, int id = 0)
        {
            var db = new DbAppContext();
            if (id != 0)
            {
                var item = db.Products.First(o => o.Id == id);
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            var list = db.Products.Where(o=>o.ProductName.Contains(query));
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomerSuggestion(string query, int id = 0)
        {
            var db = new DbAppContext();
            if (id != 0)
            {
                var item = db.Customers.First(o => o.Id == id);
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            var list =
                db.Customers.Where(
                    o => o.CustomerName.Contains(query) || o.Email.Contains(query) || o.PhoneNo.Contains(query)).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}