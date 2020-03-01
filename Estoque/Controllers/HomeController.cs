using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConexaoBD;
using System.Data;
using Estoque.Classes;

namespace Estoque.Controllers

{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Busca b = new ConexaoBD.Busca();
            var a = b.BuscaAll();
            return View();
        }
        //ainda falta adicionar o nome da categoria na tabela
        public ActionResult Tudo()
        {
            Açoes a = new Açoes();
            ViewBag.todos = a.GridTudo();
            return View();
        }

        public ActionResult Categorias()
        {

            Açoes a = new Açoes();
            ViewBag.Grid = a.GridCategorias();
            return View();
        }
        [HttpPost]
        public ActionResult Categorias(FormCollection form)
        {
            Açoes a = new Açoes();
            string b = form["Categoria"].ToString();

            ViewBag.msg = a.AddCategoria(b);
            ViewBag.Grid = a.GridCategorias();
            return View();

        }

        public ActionResult DelCategorias()
        {
            Açoes a = new Açoes();
            ViewBag.Categoria = a.GetCategorias();
            ViewBag.Grid = a.GridCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult DelCategorias(FormCollection form)
        {
            Açoes a = new Açoes();
            string b = form["Categoria"].ToString();
            ViewBag.msg = a.DelCategoria(b);
            ViewBag.Grid = a.GridCategorias();
            ViewBag.Categoria = a.GetCategorias();
            return View();
        }

        public ActionResult ChangeCategoria()
        {
            Açoes a = new Açoes();
            ViewBag.Categoria = a.GetCategorias();
            ViewBag.Grid = a.GridCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult ChangeCategoria(FormCollection form)
        {

            Açoes a = new Açoes();
            ViewBag.Grid = a.GridCategorias();
            string id = form["Categoria"].ToString();
            string newname = form["new_name"].ToString();
            ViewBag.msg = a.UpdateCategoria(id, newname);
            ViewBag.Categoria = a.GetCategorias();
            return View();
        }

        public ActionResult Produto()
        {
            Açoes a = new Açoes();
            ViewBag.Categoria = a.GetCategorias();
            ViewBag.Grid = a.GridTudo();
            return View();
        }
        [HttpPost]
        public ActionResult Produto(FormCollection form)
        {
            Açoes a = new Açoes();
            string nome = form["nomeproduto"].ToString();
            string descricao = form["descricao"].ToString();
            string categoria = form["Categoria"].ToString();
            string qtd = form["quantidade"].ToString();
            ViewBag.msg = a.AddProduto(nome, descricao, categoria, qtd);
            ViewBag.Categoria = a.GetCategorias();
            ViewBag.Grid = a.GridTudo();
            return View();


        }

        public ActionResult EditProduto()
        {
            Açoes a = new Açoes();
            ViewBag.Categoria = a.GetCategorias();
            ViewBag.Produto = a.GetProdutos();
            ViewBag.Grid = a.GridTudo();
            return View();
        }

        [HttpPost]
        public ActionResult EditProduto(FormCollection form)
        {
            Açoes a = new Açoes();

            string produtoid = form["Produto"].ToString();
            string nome = form["Nome"].ToString();
            string categoria = form["Categoria"].ToString();
            string desc = form["desc"].ToString();
            string qtd = form["qtd"].ToString();

           
            ViewBag.msg = a.UpadteProduto(produtoid, nome, categoria, desc, qtd);
            ViewBag.Categoria = a.GetCategorias();
            ViewBag.Produto = a.GetProdutos();
            ViewBag.Grid = a.GridTudo();
            return View();

        }

        public ActionResult DelProduto()
        {
            Açoes a = new Açoes();
            ViewBag.Produto = a.GetProdutos();
            ViewBag.Grid = a.GridTudo();
            return View();
        }

        [HttpPost]
        public ActionResult DelProduto(FormCollection form)
        {
            Açoes a = new Açoes();

            string produtoid = form["Produto"].ToString();
           
            ViewBag.msg = a.DelProduto(produtoid);  
            ViewBag.Produto = a.GetProdutos();
            ViewBag.Grid = a.GridTudo();
            return View();

        }
    }
}



