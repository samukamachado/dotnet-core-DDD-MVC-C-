using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SistemaPizzariaDDD.Application;
using SistemaPizzariaDDD.Domain.Models;
using SistemaPizzariaDDD.Web.Models;
using System.Diagnostics;

namespace SistemaPizzariaDDD.Web.Controllers
{
    public class EditarPedidoController : Controller
    {

        private readonly ILogger<EditarPedidoController> _logger;

        public IActionResult EditarPedido(int Id)
        {
            PedidosService service = new PedidosService();

            var pedidosModel = new PedidoClienteModel();


            var servico = service.RetornaPedidoPorID(Id);


            pedidosModel.NomeCliente = servico.NomeCliente;
            pedidosModel.Email = servico.Email;
            pedidosModel.PedidoCliente = servico.PedidoCliente;
            pedidosModel.Id = servico.Id;

            return View(pedidosModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Atualizar(PedidoClienteModel pedidoUpdate)
        {

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditarPedido(PedidoClienteModel pedido)
        {
            //
            Pedido pedidosNew = new Pedido(pedido.Id, pedido.NomeCliente, pedido.Email, pedido.PedidoCliente, pedido.Valor, pedido.Status);

            PedidosService service = new PedidosService();

            service.AlterarPedido(pedidosNew);

            return RedirectToAction("Index", "Home");

            
        }
    }

}





