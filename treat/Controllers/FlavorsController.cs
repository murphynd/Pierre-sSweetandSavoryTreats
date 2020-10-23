using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Treat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Treat.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly TreatContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(UserManager<ApplicationUser> userManager, TreatContext db)
    {
      _userManager = userManager;
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
    public ActionResult AddSnack(int id)
    {
      Snack thisSnack = _db.Snacks.FirstOrDefault(s => s.SnackId == id);
      ViewBag.SnackId = new SelectList(_db.Snacks, "SnackId", "Name");
      return View(thisSnack);
    }
    [HttpPost]
    public ActionResult AddSnack(FlavorSnack flavorSnack)
    {
      if (flavorSnack.SnackId != 0)
      {
        if (_db.FlavorSnacks.Where(x => x.SnackId == flavorSnack.SnackId && x.SnackId == flavorSnack.SnackId).ToHashSet().Count == 0)
        {
          _db.FlavorSnacks.Add(flavorSnack);
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