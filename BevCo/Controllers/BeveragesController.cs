using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BevCo.Models;
using System.Linq;

namespace BevCo.Controllers
{
  public class BeveragesController : Controller
  {
    private readonly BevCoContext _db;

    public BeveragesController(BevCoContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      // List<CategoryBeverage> thisBeverage = _db.Beverages
      //     .Include(item => item.JoinEntities)
      //     .ThenInclude(join => join.Category)
      //     .ti
      ViewBag.PageTitle = "Beverages";
      List<Beverage> model = _db.Beverages.ToList();
      ViewBag.CategoriesBeverages = _db.CategoryBeverage.ToList();
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add a beverage";
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }    
    
    [HttpPost]
    public ActionResult Create(Beverage beverage, int CategoryId)
    {
      _db.Beverages.Add(beverage);
      _db.SaveChanges();
      if (CategoryId != 0)
      {
        _db.CategoryBeverage.Add(new CategoryBeverage() { CategoryId = CategoryId, BeverageId = beverage.BeverageId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    
    
    public ActionResult Details(int id)
    {
      var thisBeverage = _db.Beverages
          .Include(item => item.JoinEntities)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(b => b.BeverageId == id);
      ViewBag.PageTitle = thisBeverage.BeverageName;
      
      foreach(var join in thisBeverage.JoinEntities)
      {
        ViewBag.PageSubTitle += join.Category.Name + ", ";
      }
      ViewBag.PageSubTitle = ViewBag.PageSubTitle.Remove(ViewBag.PageSubTitle.Length - 2, 1);
      return View(thisBeverage);
    }

    // add a delete, spice up the home page, search
  }
}