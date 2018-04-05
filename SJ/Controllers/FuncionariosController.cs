using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJ.DAL;
using SJ.Negocio;

namespace SJ.Controllers
{
    public class FuncionariosController : BaseController
    {
        // GET: Produtos
        public ActionResult Index()
        {
            FuncionarioCollection item = Funcionarios.GetAllAtivos();
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
        public ActionResult Create(Funcionario item)
        {
            try
            {
                item.Ativo = true;
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
            Funcionario item = Funcionarios.GetById(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(long Id, Funcionario item)
        {
            try
            {
                Funcionario _item = Funcionarios.GetById(Id);
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
            try
            {
                Funcionario item = Funcionarios.GetById(Id);
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