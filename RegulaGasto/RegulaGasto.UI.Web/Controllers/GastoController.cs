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
            var valorTotal = appGasto.ValorTotal();
            ViewData["Total"] = valorTotal;
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

        public ActionResult Consultar(string Categoria)
        {        
            return View();
        }

        [HttpPost, ActionName("Consultar")]
        public ActionResult ConsultarIndex(string Categoria)
        {
            var appGasto = new GastoAplicacao();
            var valortotal = appGasto.ValorTotalPorCategoria(Categoria);
            ViewData["Total"] = valortotal;
            var consulta = appGasto.ListarporCategoria(Categoria);
            if (consulta == null)
                return HttpNotFound();

            return View(consulta);
        }

        public ActionResult ListarPorMes(string Mes)
        {      
            return View();
        }

        [HttpPost, ActionName("ListarPorMes")]
        public ActionResult ListarPorMesIndex(string Mes)
        {
            var appGasto = new GastoAplicacao();
            var valorTotal = appGasto.ValorTotalPorMes(Mes);
            ViewData["Total"] = valorTotal;
            var consulta = appGasto.ListarporMes(Mes);
            if (consulta == null)
                return HttpNotFound();

            return View(consulta);
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