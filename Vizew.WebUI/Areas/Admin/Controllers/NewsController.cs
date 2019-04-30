using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vizew.WebUI.Models;
using Vizew.WebUI.Models.Entity;

namespace Vizew.WebUI.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private VizewDbContext db = new VizewDbContext();

        // GET: Admin/News
        public ActionResult Index()
        {
            var news = db.News;//.Include(n => n.Category);
            return View(news.Where(n => n.DeletedDate == null).ToList());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create(News news, HttpPostedFileBase mediaUrl)
        {
            if (mediaUrl == null)
                ModelState.AddModelError("mediaUrl", "Şəkil seçilməyib!");
            else
            {
                if (!mediaUrl.CheckImageType())
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                if (!mediaUrl.CheckImageSize(5))
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
            }

            if (ModelState.IsValid)
            {
                news.MediaUrl = mediaUrl.SaveImage(Server.MapPath("~/Template/media"));

                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit(News news, HttpPostedFileBase mediaUrl,string fileName)
        {
            News entity = db.News.Find(news.Id);
            if (entity == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ModelState.Remove("mediaUrl");

            if (mediaUrl != null)
            {
                bool valid = true;
                if (!mediaUrl.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                    valid = false;
                }

                if (!mediaUrl.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = mediaUrl.SaveImage(Server.MapPath("~/Template/media"));

                    //System.IO.File.Move(Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)),
                    //    Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)));

                    if(!string.IsNullOrWhiteSpace(entity.MediaUrl))
                    Server.MoveFile("~/Template/media"
                        , entity.MediaUrl
                        , string.Format("archive/{0}-{1}", entity.Id, entity.MediaUrl));

                    entity.MediaUrl = newPath;

                }
            }
            else if (!string.IsNullOrWhiteSpace(entity.MediaUrl) 
                && string.IsNullOrWhiteSpace(fileName))
            {
                entity.MediaUrl = null;
            }


            if (ModelState.IsValid)
            {
                entity.Title = news.Title;
                entity.Body = news.Body;
                entity.Author = news.Author;
                entity.IsPopular = news.IsPopular;
                entity.ModifiedDate = DateTime.UtcNow.AddHours(4);
                entity.CategoryId = news.CategoryId;

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            //db.News.Remove(news);
            news.DeletedDate = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
