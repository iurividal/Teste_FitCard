using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_FitCard.Models;
using Teste_FitCard.Repository;

namespace Teste_FitCard.Controllers
{
    public class EstabelecimentoController : Controller
    {

        // GET: Estabelecimento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrUpdate(string tipo)
        {
            var cat = new CategoriaRepository().GetCategoria();

            ViewBag.Categoria = new MultiSelectList(cat, "IdCategoria", "Categoria");

            return View(new EstabelecimentoModel());
        }


        [HttpPost]
        public ActionResult AddOrUpdate(EstabelecimentoModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.error = "Cadastro Realizado com Sucesso";
                }

            }
            catch (Exception e)
            {
                ViewBag.error = $"Ocorreu um problema ao tentar realizar o cadastro {e.Message}";

            }

            return View();
        }
    }
}