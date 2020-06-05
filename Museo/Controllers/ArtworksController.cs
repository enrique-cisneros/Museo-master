using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Museo.Models;

namespace Museo.Controllers
{
    [Authorize]
    public class ArtworksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AWD()
        {
            return View(db.Artworks.ToList());
        }
        // GET: Artworks
        public ActionResult Index()
        {
            var artworks = db.Artworks.Include(a => a.Artist);
            return View(artworks.ToList());
        }

        // GET: Artworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // GET: Artworks/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Nombre");
            return View();
        }

        // POST: Artworks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artwork artwork, HttpPostedFileBase hpb)
        {
            if (ModelState.IsValid)
            {
                if (hpb != null)
                {
                    var perfil = System.IO.Path.GetFileName(hpb.FileName);
                    var direccion = "~/Content/img/" + artwork.Nombre + "_" + perfil;
                    hpb.SaveAs(Server.MapPath(direccion));
                    artwork.ImgUrl = artwork.Nombre + "_" + perfil;
                }
                db.Artworks.Add(artwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Nombre", artwork.ArtistId);
            return View(artwork);
        }

        // GET: Artworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Nombre", artwork.ArtistId);
            return View(artwork);
        }

        // POST: Artworks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Tipo,Fecha,Descripcion,ImgUrl,ArtistId")] Artwork artwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Nombre", artwork.ArtistId);
            return View(artwork);
        }

        // GET: Artworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artwork artwork = db.Artworks.Find(id);
            db.Artworks.Remove(artwork);
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
