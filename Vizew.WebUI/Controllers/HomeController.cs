using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vizew.WebUI.Models;
using Vizew.WebUI.Models.Entity;

namespace Vizew.WebUI.Controllers
{
    [RoutePrefix("News")]
    public class HomeController : Controller
    {
        private VizewDbContext db = new VizewDbContext();

        public ViewResult Index()
        {
            
            var news = db.News.Where(n => n.IsPopular && n.DeletedDate == null)
                   .OrderByDescending(n => n.Id)
                   .Take(10)
                   .ToList();
            return View(news);
        }

        public ActionResult Popular()
        {
            try
            {
                var news = db.News.Where(n => n.IsPopular && n.DeletedDate == null)
                   .OrderByDescending(n => n.Id)
                   .Take(5)
                   .ToList();

                return PartialView("_PopularNews", news);
            }
            catch {
                return Content("");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //string id = Request.QueryString["id"];
            //if (string.IsNullOrWhiteSpace(id))
            //{
            //    id = Request.Form["id"];
            //}

            //string name = Request.Form["name"];
            //string email = Request.Form["email"];
            //string message = Request.Form["message"];



            ViewBag.Message = "Your application description page.";

            return View(new Contact());
        }

        [HttpPost,ActionName("Contact")]
        public ActionResult Contactx(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(contact);
        }


        public ActionResult AcrchiveGrid()
        {
            return View();
        }

        public ActionResult AcrchiveList()
        {
            return View();
        }

        [Route("{category}/{title}-{id}")]        
        public ActionResult SinglePost(int id)
        {
            var news = db.News.Find(id);
            return View(news);
        }
               
        public ActionResult VideoPost()
        {
            return View();
        }


        public ActionResult Typography()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}