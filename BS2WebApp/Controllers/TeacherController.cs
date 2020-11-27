using BS2WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS2WebApp.Controllers
{
    public class TeacherController : Controller
    {
        private static List<TeacherModel> teachers;

        public TeacherController()
        {
            if (teachers == null)
            {
                teachers = new List<TeacherModel>();

                teachers.Add(new TeacherModel { Id = 10, Name = "Jürgen", Age = 45 });
                teachers.Add(new TeacherModel { Id = 11, Name = "Kurtl", Age = 65 });
            }
        }
        // GET: BS2
        public ActionResult Teachers()
        {
            return View(teachers);
        }

        public ActionResult EditTeacher(int id)
        {
            return View(teachers.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditTeacherModel(TeacherModel model)
        {

            TeacherModel tmpTeacher = teachers.Where(x => x.Id == model.Id).FirstOrDefault();

            tmpTeacher.Name = model.Name;
            tmpTeacher.Age = model.Age;

            return RedirectToAction("Teachers");
        }

        [HttpPost]
        public ActionResult DeleteTeacher(int id)
        {
            TeacherModel tmpTeacher = teachers.Where(x => x.Id == id).FirstOrDefault();

            teachers.Remove(tmpTeacher);

            return RedirectToAction("Teachers");
        }
    }
}