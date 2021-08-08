using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace WebApplication2.Controllers
{
    public class ReservasController : Controller
    {
        private conDB conn = new conDB();
        // GET: Reservas
        public ActionResult Index()
        {
            return View(conn.tb_reserva.ToList());
        }
        public ActionResult New()
        {
            ViewBag.ListaCliente = conn.tb_cliente.ToList();
            ViewBag.ListaMascota = conn.tb_mascota.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult New(tb_reserva res)
        {
            conn.tb_reserva.Add(res);
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tb_reserva res = new tb_reserva();
            res = conn.tb_reserva.Find(id);
            return View(res);
        }
        [HttpPost]
        public ActionResult Edit(tb_reserva resnew)
        {
            tb_reserva res = new tb_reserva();
            res = conn.tb_reserva.Find(resnew.id_res);
            res.fec_res = resnew.fec_res;
            res.id_cli = resnew.id_cli;
            res.id_mas = resnew.id_mas;
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            conn.tb_reserva.Remove(conn.tb_reserva.Find(id));

            conn.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}