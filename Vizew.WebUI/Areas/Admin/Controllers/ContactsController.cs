using System;
using System.Collections.Generic;
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
    public class ContactsController : Controller
    {
        private VizewDbContext db = new VizewDbContext();

        // GET: Admin/Contacts
        public ActionResult Index()
        {
            return View(db.Contact.Where(c=>c.DeletedDate==null).ToList());
        }


        // GET: Admin/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                if (Request.IsAjaxRequest())
                    return Content("");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                if (Request.IsAjaxRequest())
                    return Content("");

                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Admin/Views/Contacts/Partial/_ContactPartial.cshtml", contact);
            }

            if (!contact.IsReady)
            {
                contact.IsReady = true;
                contact.ModifiedDate = DateTime.Now;
                db.Entry(contact).State=EntityState.Modified;
                db.SaveChanges();
            }
            return View(contact);
        }

        // GET: Admin/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            if (!contact.IsReady || contact.Answered == null)
            {
                TempData["Message"] = "Mesajı oxumadan və cavablandırmadan silə bilməzsiniz!";
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // POST: Admin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contact.Find(id);            
            contact.DeletedDate = DateTime.Now;
            db.Entry(contact).State = EntityState.Modified;
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
