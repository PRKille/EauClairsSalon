using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Create(int id)
    {
      try
      {
        Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        ViewBag.stylist = thisStylist;
        return View();
      }
      catch
      {
        return RedirectToAction("Index", "Controller");
      }
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      try
      {
        _db.Clients.Add(client);
        _db.SaveChanges();      
        return RedirectToAction("Details", "Stylist", new {id = client.StylistId});
      }
      catch
      {
        return RedirectToAction("Index", "Stylist");
      }
    }

    public ActionResult Details(int id)
    {
      try
      {
        Client currentClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        return View(currentClient);
      }
      catch
      {
        return RedirectToAction("Index", "Stylist");
      }
    }

    public ActionResult Edit(int id)
    {
      try
      {
        Client currentClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        return View(currentClient);
      }
      catch
      {
        return RedirectToAction("Index", "Stylist");
      }
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      try
      {  
        _db.Entry(client).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = client.ClientId });
      }
      catch
      {
        return RedirectToAction("Index", "Stylist");
      }
    }

    public ActionResult Delete(int id)
    {
      try
      {
        Client currentClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        return View(currentClient);
      }
      catch
      {
        return RedirectToAction("Index", "Stylist");
      }
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult ConfirmDelete(int id)
    {
      try
      {
        Client currentClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        _db.Clients.Remove(currentClient);
        _db.SaveChanges();
        return RedirectToAction("Details", "Stylist", new {id = currentClient.StylistId});
      }
      catch
      {
        return RedirectToAction("Index", "Stylist");
      }
    }
  }
}