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
  public class SnacksController : Controller
  {
    private readonly TreatContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public SnacksController(UserManager<ApplicationUser> userManager, TreatContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public ActionResult Index()
    {
      List<Snack> model = _db.Snacks.OrderBy(x => x.Name).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Snack Snack)
    {
      _db.Snacks.Add(Snack);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddFlavor(int id)
    {
      Snack thisSnack = _db.Snacks.FirstOrDefault(s => s.SnackId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisSnack);
    }
    [HttpPost]

    public ActionResult AddFlavor(FlavorSnack flavorsnack)
    {
      if (flavorsnack.FlavorId != 0)
      {
        if (_db.FlavorSnacks.Where(x => x.SnackId == flavorsnack.SnackId && x.FlavorId == flavorsnack.FlavorId).ToHashSet().Count == 0)
        {
          _db.FlavorSnacks.Add(flavorsnack);
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Snack model = _db.Snacks.FirstOrDefault(x => x.SnackId == id);
      return View(model);
    }
    public ActionResult Delete(int id)
    {
      var thisSnack = _db.Snacks.FirstOrDefault(x => x.SnackId == id);
      return View(thisSnack);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSnack = _db.Snacks.FirstOrDefault(x => x.SnackId == id);
      _db.Snacks.Remove(thisSnack);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisSnack = _db.Snacks.FirstOrDefault(x => x.SnackId == id);
      return View(thisSnack);
    }
    [HttpPost]
    public ActionResult Edit(Snack Snack)
    {
      _db.Entry(Snack).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}