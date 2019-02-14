using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageData))
                return View("List");
            else
                return View("ReadOnly");
        }
    }
}