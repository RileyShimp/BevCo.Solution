using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BevCo.Models;
using System.Linq;

namespace BevCo.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly BevCoContext _db;

    public CategoriesController(BevCoContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Categories";
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = "Create a category";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index", "Categories"); 
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Categories");
    }

    public ActionResult Edit(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Details(int id)
    {
      Category thisCategory = _db.Categories
                      .Include(i => i.JoinEntities)
                      .ThenInclude(join => join.Beverage)
                      .FirstOrDefault(c => c.CategoryId == id);
      ViewBag.PageTitle = thisCategory.Name;  
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult Delete (int id)
    {
      var joinEntry = _db.Categories.FirstOrDefault(entry => entry.CategoryId == id);
      _db.Categories.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
  }
}