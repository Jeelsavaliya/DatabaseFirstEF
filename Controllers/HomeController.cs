using DatabaseFirstEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatabaseFirstEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseFirstDbContext studentDB;

        public HomeController(ILogger<HomeController> logger, DatabaseFirstDbContext studentDB)
        {
            _logger = logger;
            this.studentDB = studentDB;
        }

        #region Index
        public IActionResult Index()
        {
            var stdData = studentDB.Students.ToList();
            return View(stdData);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentDB.Students.Add(student);
                studentDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            var student = studentDB.Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            var student = studentDB.Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentDB.Students.Update(student);
                studentDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            var stdData = studentDB.Students.FirstOrDefault(item => item.Id == id);
            return View(stdData);
        }

        [HttpPost]
        public IActionResult Delete(Student std)
        {
            var stdData = studentDB.Students.FirstOrDefault(item => item.Id == std.Id);
            studentDB.Students.Remove(stdData);
            studentDB.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
