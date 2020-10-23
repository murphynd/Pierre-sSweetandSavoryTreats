using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Treat.Models;

namespace Treat.Controllers
{
  public class TreatsController : Controller
  {
    private readonly TreatContext _db;
    public TreatsController(TreatContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.OrderBy(x => x.Name).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Treat Treat)
    {
      _db.Treats.Add(Treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddFlavor(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(s => s.FlavorId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisFlavor);
    }
    [HttpPost]
    public ActionResult AddFlavor(FlavorFlavor flavorFlavor)
    {
      if (flavorFlavor.FlavorId != 0)
      {
        if (_db.FlavorFlavors.Where(x => x.FlavorId == flavorFlavor.FlavorId && x.FlavorId == flavorFlavor.FlavorId).ToHashSet().Count == 0)
        {
          _db.FlavorFlavors.Add(flavorFlavor);
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Treat model = _db.Treats.FirstOrDefault(x => x.TreatId == id);
      return View(model);
    }
    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(x => x.TreatId == id);
      return View(thisTreat);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(x => x.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(x => x.TreatId == id);
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult Edit(Treat Treat)
    {
      _db.Entry(Treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}