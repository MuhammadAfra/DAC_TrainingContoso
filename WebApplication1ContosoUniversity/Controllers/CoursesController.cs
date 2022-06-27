using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1ContosoUniversity.DAL;
using WebApplication1ContosoUniversity.Models;
using PagedList;

namespace WebApplication1ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Courses
        public ActionResult Index(String sortOrder, String currentFilterTitle, String currentFilterCredits,
                                  String searchStringTitle, String searchStringCredits,  int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : " ";
            ViewBag.CreditsSortParm = sortOrder == "Credits" ? "credits_desc" : "Credits";

            var course = from s in db.Courses
                           select s;

            //1.Memfilter berdasarkan Title

            if (searchStringTitle != null)
            {
                page = 1;
            }
            else
            {
                searchStringTitle = currentFilterTitle;
            }

            ViewBag.CurrentFilterTitle = searchStringTitle;

            if (!String.IsNullOrEmpty(searchStringTitle))
            {
                course = course.Where(s => s.Title.Contains(searchStringTitle));
            }

            //2.Memfilter berdasarkan Credits

            if (searchStringCredits != null)
            {
                page = 1;
            }
            else
            {
                searchStringCredits = currentFilterCredits;
            }

            ViewBag.CurrentFilterCredits = searchStringCredits;

            if (!String.IsNullOrEmpty(searchStringCredits))
            {
                course = course.Where(s => s.Credits.ToString().Contains(searchStringCredits));
            }

            //3 Sorting (Pengurutan)

            switch (sortOrder)
            {
                case "title_desc":
                    course = course.OrderByDescending(s => s.Title);
                    break;
                case "Credits":
                    course = course.OrderBy(s => s.Credits);
                    break;
                case "credits_desc":
                    course = course.OrderByDescending(s => s.Credits);
                    break;
                default:
                    course = course.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(course.ToPagedList(pageNumber, pageSize));
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
