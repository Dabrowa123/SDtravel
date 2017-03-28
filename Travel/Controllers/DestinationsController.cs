using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class DestinationsController : Controller
    {
        private TravelModelContainer db = new TravelModelContainer();

       
        // GET: Destinations
        public ActionResult Index(string SearchString, string SiteLocation, string SiteDestination)
        {
            //--- Location Dropdown --//
            var LocationList = new List<string>();

            var LocationQry = from k in db.Sites
                              orderby k.SiteLocation
                              select k.SiteLocation;

            LocationList.AddRange(LocationQry.Distinct());

            ViewBag.SiteLocation = new SelectList(LocationList);

            //--- Destination Dropdown --//
            var DestinationList = new List<string>();

            var DestinationQry = from d in db.Sites
                                 orderby d.SiteDestination
                                 select d.SiteDestination;

            DestinationList.AddRange(DestinationQry.Distinct());
            ViewBag.siteDestination = new SelectList(DestinationList);

            //-----//

            var site = from m in db.Sites
                       select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                site = site.Where(s => s.SiteName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SiteLocation))
            {
                site = site.Where(x => x.SiteLocation == SiteLocation);
            }

            if (!string.IsNullOrEmpty(SiteDestination))
            {
                site = site.Where(x => x.SiteDestination == SiteDestination);
            }
                        
            return View(site);
        }

        
        [ChildActionOnly]
        public ActionResult SearchBox()

        {
            //--- Destination Dropdown --//
            var DestinationList = new List<string>();

            var DestinationQry = from d in db.Sites
                                 orderby d.SiteDestination
                                 select d.SiteDestination;

            DestinationList.AddRange(DestinationQry.Distinct());
           
            ViewBag.SiteDestination = new SelectList(DestinationList);

            //--- Location Dropdown --//
            var LocationList = new List<string>();

            var LocationQry = from d in db.Sites
                                 orderby d.SiteLocation
                                 select d.SiteLocation;

            LocationList.AddRange(LocationQry.Distinct());

            ViewBag.SiteLocation = new SelectList(LocationList);

            return PartialView();
        }   

        // GET: Destinations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // GET: Destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteId,SiteName,SiteLocation,SiteDescription")] Site site)
        {
            if (ModelState.IsValid)
            {
                db.Sites.Add(site);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(site);
        }

        // GET: Destinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteId,SiteName,SiteLocation,SiteDescription")] Site site)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        // GET: Destinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site site = db.Sites.Find(id);
            db.Sites.Remove(site);
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
