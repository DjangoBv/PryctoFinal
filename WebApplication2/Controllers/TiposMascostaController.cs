using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace WebApplication2.Controllers
{
    public class TiposMascostaController : Controller
    {
        private conDB conn = new conDB();
        // GET: TiposMascosta
        public ActionResult Index()
        {
            return View(conn.tb_tipoMascota.ToList());
        }
    }
}