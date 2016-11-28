using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnLineHotelOs.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index(string look) //-----------------------------------------新添加一个博客主页 //博客内嵌搜索功能
        {
            var db = new OsDatabase();

            db.Database.CreateIfNotExists();

            // var lst = db.RoomArticles.OrderByDescending(o => o.Id).ToList();
            // ViewBag.RoomArticles = lst;
            var lst = db.RoomArticles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(look))
            {
                lst = lst.Where(o => o.Subject.Contains(look));
            }

            ViewBag.RoomArticles = lst.OrderByDescending(o => o.Id).ToList();
            ViewBag.look = look;
            return View();
        }


        public ActionResult AddRoom()//-----------------------------------------新添加一个博客添加页面
        {

            return View();


        }

        public ActionResult ArticleSave(RoomArticle model)//-----------------------------------------新添加一个博客保存功能
        {
            var article = new RoomArticle();

            article.Subject = model.Subject;
            article.Body = model.Body;
            article.Khage = model.Khage;
            article.Id = model.Id;
            article.Khid = model.Khid;
            article.Khname = model.Khname;
            article.Khphone = model.Khphone;
            article.Khsex = model.Khsex;
            article.Roomid = model.Roomid;
            article.Rzdate = model.Rzdate;
            article.Rzid = model.Rzid;
            article.RzTfdate = model.RzTfdate;
            article.DateCreated = DateTime.Now;

            var db = new OsDatabase();
            db.RoomArticles.Add(article);
            db.SaveChanges();

            return Redirect("Index");
        }

        public ActionResult Show(int id)        //-----------------------------------------新添加一个博客显示功能
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }
        public ActionResult Change(int id)//-----------------------------------------新添加一个博客修改界面
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();


        }
        public ActionResult ChangeSave(int id, string subject, string body, string Khname, int Khage, string Khsex, string Khid, string Khphone, string Roomid, string Rzid, DateTime Rzdate, DateTime RzTfdate)//-----------------------------------------新添加一个博客修改刷新功能
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            article.Subject = subject;
            article.Body = body;
            article.Khage = Khage;
            article.Id = id;
            article.Khid = Khid;
            article.Khname = Khname;
            article.Khphone = Khphone;
            article.Khsex = Khsex;
            article.Roomid = Roomid;
            article.Rzdate = Rzdate;
            article.Rzid = Rzid;
            article.RzTfdate = RzTfdate;



            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)//-----------------------------------------新添加一个博客删除
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            db.RoomArticles.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }

}