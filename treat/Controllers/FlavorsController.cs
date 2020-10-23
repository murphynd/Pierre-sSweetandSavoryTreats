using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Treat.Models;

namespace Treat.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly TreatContext _db;
    public FlavorsController(TreatContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.OrderBy(x => x.Name).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddTreat(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(s => s.TreatId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult AddTreat(FlavorTreat flavorTreat)
    {
      if (flavorTreat.TreatId != 0)
      {
        if (_db.FlavorTreats.Where(x => x.TreatId == flavorTreat.TreatId && x.TreatId == flavorTreat.TreatId).ToHashSet().Count == 0)
        {
          _db.FlavorTreats.Add(flavorTreat);
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Flavor model = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
      return View(model);
    }
    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
      return View(thisFlavor);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(x => x.FlavorId == id);
      return View(thisFlavor);
    }
    [HttpPost]
    public ActionResult Edit(Flavor Flavor)
    {
      _db.Entry(Flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}