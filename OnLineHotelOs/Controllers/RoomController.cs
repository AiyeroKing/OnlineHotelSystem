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
        public ActionResult Index(string look) //-----------------------------------------�����һ��������ҳ //������Ƕ��������
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


        public ActionResult AddRoom()//-----------------------------------------�����һ���������ҳ��
        {

            return View();


        }

        public ActionResult ArticleSave(RoomArticle model)//-----------------------------------------�����һ�����ͱ��湦��
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

        public ActionResult Show(int id)        //-----------------------------------------�����һ��������ʾ����
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }
        public ActionResult Change(int id)//-----------------------------------------�����һ�������޸Ľ���
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();


        }
        public ActionResult ChangeSave(int id, string subject, string body, string Khname, int Khage, string Khsex, string Khid, string Khphone, string Roomid, string Rzid, DateTime Rzdate, DateTime RzTfdate)//-----------------------------------------�����һ�������޸�ˢ�¹���
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
        public ActionResult Delete(int id)//-----------------------------------------�����һ������ɾ��
        {
            var db = new OsDatabase();
            var article = db.RoomArticles.First(o => o.Id == id);

            db.RoomArticles.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }

}