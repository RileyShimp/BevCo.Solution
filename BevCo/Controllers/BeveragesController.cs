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
//     public ActionResult Index()
    // {
    //   List<Course> model = _db.Courses.ToList();
    //   return View(model);
    // }
    // public ActionResult Create()
    // {
    //   ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentCourseAbv");
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult Create(Course course)
    // {
    //   _db.Courses.Add(course);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index", "Courses"); 
    // }

    // public ActionResult Details(int id)
    // {
    //   Client thisClient = _db.Clients.FirstOrDefault(c => c.ClientId == id);
    //   return View(thisClient);
    // }

    
  }
}