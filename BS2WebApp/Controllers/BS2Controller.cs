using BS2WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS2WebApp.Controllers
{
    public class BS2Controller : Controller
    {
        private static List<StudentModel> students;

        public BS2Controller()
        {
            if (students == null)
            {
                students = new List<StudentModel>();

                students.Add(new StudentModel { Id = 10, Name = "Hugo" });
                students.Add(new StudentModel { Id = 11, Name = "Peter" });
            }
        }
        // GET: BS2
        public ActionResult Students()
        {
            return View(students);
        }

        public ActionResult EditStudent (int id)
        {
            if (id == 0)
            {
                return View(new StudentModel());
            }

            return View(students.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditStudent(StudentModel model)
        {
            //return View("EditStudent", model);

            if (model.Id == 0)
            {
                if (students.Count <= 0)
                {
                    model.Id = 1;
                }
                else
                {
                    model.Id = students.Max(x => x.Id) + 1;
                }
               
                students.Add(model);

                return RedirectToAction("Students");
            }

            StudentModel tmpStudent = students.Where(x => x.Id == model.Id).FirstOrDefault();

            tmpStudent.Name = model.Name;

            return RedirectToAction("Students");
        }

        public ActionResult DeleteStudent(int id)
        {
            StudentModel tmpStudent = students.Where(x => x.Id == id).FirstOrDefault();

            students.Remove(tmpStudent);

            return RedirectToAction("Students");
        }
    }
}