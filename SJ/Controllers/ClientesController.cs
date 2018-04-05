using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJ.DAL;
using SJ.Negocio;

namespace SJ.Controllers
{
    public class ClientesController : BaseController
    {
        // GET: Produtos
        public ActionResult Index()
        {
            ClienteCollection item = Clientes.GetAll();
            if (TempData["mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["mensagem"];
            }
            else if (TempData["mensagemErro"] != null)
            {
                ViewBag.MensagemErro = TempData["mensagemErro"];
            }
            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente item)
        {
            try
            {
                item.Save();
                TempData["mensagem"] = "Registro salvo com sucesso!";
            }
            catch (Exception e)
            {
                TempData["mensagemErro"] = "Houve um erro: " + e.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(long Id)
        {
            Cliente item = Clientes.GetById(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(long Id, Cliente item)
        {
            try
            {
                Cliente _item = Clientes.GetById(Id);
                _item.Nome = item.Nome;
                _item.Telefone = item.Telefone;
                _item.Celular = item.Celular;
                _item.Save();
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

            if (Clientes.Delete(Id))
            {
                TempData["mensagem"] = "Registro deletado com sucesso!";
            }
            else
            {
                TempData["mensagemErro"] = "Houve um erro: não foi possivel deletar o produto";
            }
            return RedirectToAction("Index");
        }
    }
}