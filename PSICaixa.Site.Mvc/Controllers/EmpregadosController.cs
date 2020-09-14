using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Services.Empregados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSICaixa.Site.Mvc.Controllers
{
    public class EmpregadosController : Controller
    {
        private readonly IEmpregadoService EmpregadoService;

        public EmpregadosController(IEmpregadoService empregadoService)
        {
            EmpregadoService = empregadoService;
        }

        // GET: Empregados
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarEmpregados()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            //string searchValue = Request["search[Value]"];
            //string sortComumnName = Request["Columns[" + Request["order[0][column]"] + "][name]"];
            //string sortDirection = Request["order[0][dir]"];

            var totalEmpregados = EmpregadoService.RetornarListaEmpregados().Count();

            var listaEmpregados = EmpregadoService.ListarEmpregadosPorPaginacao(start, length);


            return Json(new {recordsFiltered = totalEmpregados, recordsTotal = totalEmpregados, data = listaEmpregados}, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult SalvarArquivo(HttpPostedFileBase file)
        {
            try
            {

                string pastaLocal = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/");

                var httpRequest = System.Web.HttpContext.Current.Request;

                /*Pega a coleção de arquivos sobre o Post*/
                System.Web.HttpFileCollection fileColl = System.Web.HttpContext.Current.Request.Files;

                var arquivo = fileColl.Get("arquivo");

                var listaEmpregados = EmpregadoService.LerArquivo(arquivo.InputStream);

                return View();
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Empregados/Details/5
        public ActionResult RelacaoDeEmpregados(int id)
        {
            return View();
        }

        // GET: Empregados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empregados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empregados/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empregados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empregados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empregados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empregados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
