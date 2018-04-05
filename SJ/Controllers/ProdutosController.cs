using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJ.DAL;
using SJ.Negocio;

namespace SJ.Controllers
{
    public class ProdutosController : BaseController
    {
        // GET: Produtos
        public ActionResult Index()
        {
            ProdutoCollection produtos = Produtos.GetAllAtivos();
            if (TempData["mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["mensagem"];
            }
            else if(TempData["mensagemErro"] != null){
                ViewBag.MensagemErro = TempData["mensagemErro"];
            }
            return View(produtos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                produto.Ativo = true;
                produto.Save();
                TempData["mensagem"] = "Registro salvo com sucesso!";
            }
            catch (Exception e)
            {
                TempData["mensagemErro"] = "Houve um erro: "+e.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(long Id)
        {
            Produto produto = Produtos.GetById(Id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Update(long Id,Produto produto)
        {
            try
            {
                Produto _produto = Produtos.GetById(Id);
                _produto.Nome = produto.Nome;
                _produto.Valor = produto.Valor;
                _produto.Tipo = produto.Tipo;
                _produto.Save();
                TempData["mensagem"] = "Registro editado com sucesso!";
            }
            catch (Exception e)
            {
                TempData["mensagemErro"] = "Houve um erro: " + e.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long Id)
        {
            try
            {
                Produto item = Produtos.GetById(Id);
                item.Ativo = false;
                item.Save();
                TempData["mensagem"] = "Registro deletado com sucesso!";
            }
            catch
            {
                TempData["mensagemErro"] = "Houve um erro: não foi possivel deletar o produto";
            }
            return RedirectToAction("Index");
        }
    }
}