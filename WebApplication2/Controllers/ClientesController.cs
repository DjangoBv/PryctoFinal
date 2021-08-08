using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace WebApplication2.Controllers
{
    public class ClientesController : Controller
    {
        private conDB conn = new conDB();
        // GET: Clientes
        public ActionResult Index()
        {
            return View(conn.tb_cliente.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(tb_cliente cli)
        {
            conn.tb_cliente.Add(cli);
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tb_cliente cli = new tb_cliente();
            cli = conn.tb_cliente.Find(id);
            return View(cli);
        }
        [HttpPost]
        public ActionResult Edit(tb_cliente clinew)
        {
            tb_cliente cli = new tb_cliente();
            cli = conn.tb_cliente.Find(clinew.id_cli);
            cli.nom_cli = clinew.nom_cli;
            cli.ape_cli = clinew.ape_cli;
            cli.telFijo_cli = clinew.telFijo_cli;
            cli.telMovil_cli = clinew.telMovil_cli;
            cli.cor_cli = clinew.cor_cli;
            cli.dir_cli = clinew.dir_cli;
            conn.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            conn.tb_cliente.Remove(conn.tb_cliente.Find(id));

            conn.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}