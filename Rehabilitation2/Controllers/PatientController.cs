using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehabilitation2.Models.Entity;
namespace Rehabilitation.Controllers
{
    public class PatientController : Controller
    {
        RehabilitationDbEntities1 db = new RehabilitationDbEntities1();
        // GET: Patient
        public ActionResult Index()
        {
            var patients = db.TBLPATIENT.ToList();
            return View(patients);
        }

        [HttpGet]
        public ActionResult NewPatient()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult NewPatient(TBLPATIENT p1)
        {
            db.TBLPATIENT.Add(p1);
            db.SaveChanges();
            return View();

        }

        public ActionResult Delete(int id)
        {
            var pat = db.TBLPATIENT.Find(id);
            db.TBLPATIENT.Remove(pat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaGetir(int id)
        {
            var pat = db.TBLPATIENT.Find(id);
            return View("HastaGetir", pat);
        }

        public ActionResult Update(TBLPATIENT p1)
        {
            var pat = db.TBLPATIENT.Find(p1.PATIENTID);
            pat.PATIENTNAME = p1.PATIENTNAME;
            pat.PATIENTSURNAME = p1.PATIENTSURNAME;
            pat.PATIENTAGE = p1.PATIENTAGE;
            pat.PATIENTGENDER = p1.PATIENTGENDER;
            pat.PATIENTEHA = p1.PATIENTEHA;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}