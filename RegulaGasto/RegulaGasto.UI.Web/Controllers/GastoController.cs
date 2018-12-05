using RegulaGasto.Aplicacao;
using RegulaGasto.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegulaGasto.UI.Web.Controllers
{
    public class GastoController : Controller
    {
        // GET: Gasto
        public ActionResult Index()
        {
            var appGasto = new GastoAplicacao();
            var listadeGastos = appGasto.ListaTodos();
            return View(listadeGastos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                var appGasto = new GastoAplicacao();
                appGasto.Salvar(gasto);
                return RedirectToAction("Index");
            }
            return View(gasto);
        }

        public ActionResult Editar(int id)
        {
            var appGasto = new GastoAplicacao();
            var gasto = appGasto.ListarPorId(id);
            if (gasto == null)
                return HttpNotFound();
            return View(gasto);                       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                var appGasto = new GastoAplicacao();
                appGasto.Salvar(gasto);
                return RedirectToAction("Index");
            }
            return View(gasto);
        }

        public ActionResult Detalhes(int id)
        {
            var appGasto = new GastoAplicacao();
            var gasto = appGasto.ListarPorId(id);
            if (gasto == null)
                return HttpNotFound();
            return View(gasto);
        }

        public ActionResult Excluir(int id)
        {
            var appGasto = new GastoAplicacao();
            var gasto = appGasto.ListarPorId(id);
            if (gasto == null)
                return HttpNotFound();
            return View(gasto);
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmar(int id)
        {
            var appGasto = new GastoAplicacao();
            appGasto.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}