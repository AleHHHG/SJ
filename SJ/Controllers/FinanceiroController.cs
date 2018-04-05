using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJ.DAL;
using SJ.Negocio;
namespace SJ.Controllers
{
    public class FinanceiroController : BaseController
    {
        // GET: Financeiro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Financeiro
        public ActionResult Pedidos()
        {
            return View();
        }

        // GET: Cria Pedido
        public ActionResult Pedido()
        {
            ProdutoCollection produtos = Produtos.GetAllAtivos();
            ViewBag.SelectList = new SelectList(SJ.Negocio.FormasPagamento.GetAll(), "id", "nome");
            return View(produtos);
        }

        [HttpPost]
        public JsonResult Pedido(SJ.Models.Pedido pedido)
        {
            try
            {
                SJ.DAL.Financeiro _pedido = new SJ.DAL.Financeiro();
                _pedido.UsuarioId = 1;
                _pedido.FormaPagamentoId = pedido.forma_pagamento;
                _pedido.DataCadastro = DateTime.Now;
                _pedido.Tipo = 1; //entrada
                _pedido.Observacao = pedido.observacao;
                _pedido.Valor = (decimal) pedido.itens.Sum(x => x.valor);
                _pedido.Save();
                foreach(var item in pedido.itens)
                {
                    SJ.DAL.FinanceiroItem _item = new SJ.DAL.FinanceiroItem();
                    _item.AbrangenciaId = 1;
                    _item.FinanceiroId = _pedido.Id;
                    _item.Valor = item.valor;
                    _item.Quantidade = item.quantidade;
                    _item.IdAbrangencia = item.id;
                    _item.Save();
                }
                return Json(new { sucesso = true, pedido_id = _pedido.Id, mensagem = "Pedido criado com sucesso." });
            }
            catch(Exception e)
            {
                return Json(new { sucesso = false, mensagem = "Houve um erro: "+e.Message });
            }
        }

        public ActionResult Show(long Id)
        {
            SJ.DAL.Financeiro pedido = SJ.Negocio.Financeiro.GetById(Id);
            return View(pedido);
        }
    }
}