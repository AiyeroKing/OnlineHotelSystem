using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnLineHotelOs.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult LoginView()
        {
            return View();
        }
        public ActionResult Login(Admain model)
        {
            var state = false;
            if (ModelState.IsValid)
            {
                var db = new OsDatabase();
                db.Database.CreateIfNotExists();

                var lst = db.Admins.AsQueryable();
                lst = lst.Where(o => o.UserName.Contains(model.UserName));
                foreach(var a in lst)
                {
                    if (a.UserName == model.UserName && a.UserMima == model.UserMima)
                    {
                        state = true;
                    }
                    else state = false;
                }
            }
            if (state == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else return Redirect("LoginView");
            
        }
        public ActionResult SetupNMView()
        {
            return View();
        }
        public ActionResult SetupNM(Admain model)
        {
            var account = new Admain();
            account.Id = model.Id;
            account.UserName = model.UserName;
            account.UserMima = model.UserMima;
            var db = new OsDatabase();
            db.Admins.Add(account);
            db.SaveChanges();
            return Redirect("LoginView");
        }
    }
}