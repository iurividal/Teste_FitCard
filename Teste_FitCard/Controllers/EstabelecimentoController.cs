using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Teste_FitCard.Models;
using Teste_FitCard.Repository;

namespace Teste_FitCard.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private Repository.EstabelecimentoRepository _repository = new EstabelecimentoRepository();

        // GET: Estabelecimento
        public ActionResult Index()
        {
            TempData["ESTABELICIMENTOLIST"] = _repository.GetAll();

            return View();
        }

        public ActionResult AddOrUpdate(string id)
        {
            CarregaCategoria();
            CarregaEstadosECidades();


            var model = new EstabelecimentoModel();
            if (!string.IsNullOrEmpty(id))
            {
                CarregaEstadosECidades();
                model = _repository.GetAll().First(a => a.IdEstabelecimento == Convert.ToInt32(id));
                
            }




            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(EstabelecimentoModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddorUpdate(model);


                    ViewBag.sucesso = "Dados Salvo com sucesso";

                }


            }
            catch (Exception e)
            {
                ViewBag.error = $"Ocorreu um problema ao tentar gravar os dados {e.Message}";

            }

            CarregaCategoria();
            CarregaEstadosECidades();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(id);

            TempData["ESTABELICIMENTOLIST"] = _repository.GetAll();

            return View("Index");
        }

        private void CarregaCategoria()
        {
            var cat = new CategoriaRepository().GetCategoria();

            TempData["CategoriaList"] = new MultiSelectList(cat, "IdCategoria", "Categoria");
        }

        private void CarregaEstadosECidades()
        {

            var servicos = new Servicos.IGBE_Service();
            var estados = servicos.GetEstados().OrderBy(a => a.nome).ToList();


            Parallel.Invoke(() =>
            {
                var states = new List<SelectListItem>();
                estados.ForEach(item =>
                {
                    states.Add(new SelectListItem { Text = item.nome, Value = item.sigla });

                });
                ViewBag.States = states;
            },
                
                () =>
                {
                    var cidades = servicos.GetCidades().ToList();
                    var cidadeList = new List<SelectListItem>();
                    cidades.ForEach(item =>
                    {
                        cidadeList.Add(new SelectListItem { Text = item.nome, Value = item.nome });
                    });

                    ViewBag.Cidades = cidadeList;
                });

        }


        [HttpPost]
        public JsonResult GetCidade(string uf)
        {
            var cidades = new Servicos.IGBE_Service().GetCidades(uf);

            return Json(new SelectList(cidades, "nome", "nome"));
        }


    }
}