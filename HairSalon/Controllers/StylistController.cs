using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
  public class StylistController : Controller 
  {
    private readonly HairSalonContext _db;

    public StylistController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      try
      {
        List<Stylist> model = _db.Stylists.ToList();
        return View(model);
      }
      catch
      {
        return RedirectToAction("Index", "Home");
      }
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      try
      {
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      try
      {
        Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        currentStylist.Clients = _db.Clients.Where(client => client.StylistId == id).ToList();
        return View(currentStylist);
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }

    public ActionResult Edit(int id)
    {
      try
      {
        Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(thisStylist);
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      try
      {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = stylist.StylistId } );
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }

    public ActionResult Delete(int id)
    {
      try
      {
        Stylist stylistToDelete = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        stylistToDelete.Clients = _db.Clients.Where(client => client.StylistId == id).ToList();
        return View(stylistToDelete);
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      try
      {
        Stylist stylistToDelete = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        stylistToDelete.Clients = _db.Clients.Where(client => client.StylistId == id).ToList();
        foreach(Client client in stylistToDelete.Clients)
        {
          _db.Clients.Remove(client);
        }
        _db.Stylists.Remove(stylistToDelete);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      catch
      {
        return RedirectToAction("Index");
      }
    }
  }
}