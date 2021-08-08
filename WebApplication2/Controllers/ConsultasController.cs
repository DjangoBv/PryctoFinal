using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace WebApplication2.Controllers
{
    public class ConsultasController : Controller
    {
        private conDB conn = new conDB();
        // GET: Consultas
        public ActionResult Index()
        {
            return View(conn.tb_consulta.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            ViewBag.ListaMascota = conn.tb_mascota.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult New(tb_consulta cons)
        {
            conn.tb_consulta.Add(cons);
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tb_consulta cons = new tb_consulta();
            cons = conn.tb_consulta.Find(id);
            return View(cons);
        }
        [HttpPost]
        public ActionResult Edit(tb_consulta consnew)
        {
            tb_consulta cons = new tb_consulta();
            cons = conn.tb_consulta.Find(consnew.id_cons);
            cons.fec_cons = consnew.fec_cons;
            cons.sint_cons = consnew.sint_cons;
            cons.diag_cons = consnew.diag_cons;
            cons.id_mas = consnew.id_mas;
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            conn.tb_consulta.Remove(conn.tb_consulta.Find(id));

            conn.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}