using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationmodel.Models;
using UserRegistrationmodel.ADO.DAO;

namespace UserRegistrationmodel.Controllers
{
    public class userController : Controller
    {
        Crud cr = new Crud();
        // GET: user
        public ActionResult Index()
        {
            List<userdata> data = cr.Read("userData");
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(userdata data)
        {
            cr.Create(data, "userdata");
            return RedirectToAction("/");
        }
    }
}