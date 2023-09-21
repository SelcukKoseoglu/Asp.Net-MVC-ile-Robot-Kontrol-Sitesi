using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehabilitation2.Models.Entity;
namespace Rehabilitation.Controllers
{
    public class ExerciseController : Controller
    {
        RehabilitationDbEntities1 db = new RehabilitationDbEntities1();
        // GET: Exercise

        public ActionResult Index()
        {
            var exercises = db.TBLSESSION.ToList();
            return View(exercises);
        }
        [HttpGet]
        public ActionResult StartExercise()
        {
            List<SelectListItem> degerler = (from i in db.TBLPATIENT.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.PATIENTNAME,
                                                 Value = i.PATIENTID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            List<SelectListItem> degerler2 = (from i in db.TBLEXERCISE.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.EXERCISENAME,
                                                  Value = i.EXERCISEID.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View();
        }
        [HttpPost]
        public ActionResult StartExercise(TBLSESSION p1)
        {
            var ses = db.TBLPATIENT.Where(m => m.PATIENTID == p1.TBLPATIENT.PATIENTID).FirstOrDefault();
            p1.TBLPATIENT = ses;
            var ses2 = db.TBLEXERCISE.Where(m => m.EXERCISEID == p1.TBLEXERCISE.EXERCISEID).FirstOrDefault();
            p1.TBLEXERCISE = ses2;
            db.TBLSESSION.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Working");
        }

        public ActionResult Working()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var ses = db.TBLSESSION.Find(id);
            db.TBLSESSION.Remove(ses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}