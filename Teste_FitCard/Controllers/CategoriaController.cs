using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_FitCard.Models;
using Teste_FitCard.Repository;

namespace Teste_FitCard.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaRepository _cr = new CategoriaRepository();
        // GET: Categoria
        public ActionResult Index()
        {
            return View(_cr.GetCategoria());
        }

        [HttpPost]
        public ActionResult Index(CategoriaModel model)
        {

            _cr.AddOrUpdate(model);

            return View(_cr.GetCategoria());
        }


        public ActionResult Delete(int id)
        {
            _cr.Delete(id);
            return RedirectToAction("Index");
        }
    }
}