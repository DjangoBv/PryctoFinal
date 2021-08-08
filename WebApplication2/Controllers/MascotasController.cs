using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace WebApplication2.Controllers
{
    public class MascotasController : Controller
    {
        private conDB conn = new conDB();
        // GET: Mascotas
        public ActionResult Index()
        {
            return View(conn.tb_mascota.ToList());
        }
        public ActionResult New()
        {
            ViewBag.ListaCliente = conn.tb_cliente.ToList();
            ViewBag.ListaTipoMascota= conn.tb_tipoMascota.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult New(tb_mascota mas)
        {
            conn.tb_mascota.Add(mas);
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tb_mascota mas = new tb_mascota();
            mas = conn.tb_mascota.Find(id);
            return View(mas);
        }
        [HttpPost]
        public ActionResult Edit(tb_mascota masnew)
        {
            tb_mascota mas = new tb_mascota();
            mas = conn.tb_mascota.Find(masnew.id_mas);
            mas.nom_mas = masnew.nom_mas;
            mas.fecNacimiento_mas = masnew.fecNacimiento_mas;
            mas.raza_mas = masnew.raza_mas;
            mas.id_cli = masnew.id_cli;
            mas.id_tipMas = masnew.id_tipMas;
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            conn.tb_mascota.Remove(conn.tb_mascota.Find(id));

            conn.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}