using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaPizzariaDDD.Domain.Models;
using SistemaPizzariaDDD.Web.Models;
using SistemaPizzariaDDD.Application;


namespace SistemaPizzariaDDD.Web.Controllers
{
    [Route("[controller]")]
    public class PedidoClienteController : Controller
    {
        private readonly ILogger<PedidoClienteController> _logger;

        public PedidoClienteController(ILogger<PedidoClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!"); 
        }

        [HttpPost]
        public ActionResult PedidoCliente(PedidoClienteModel pedido)
        {

            Pedido pedidosNew = new Pedido(0, pedido.NomeCliente, pedido.Email, pedido.PedidoCliente, 0, "");

            PedidosService service = new PedidosService();

            service.CriarPedido(pedidosNew);

            return RedirectToAction("Index", "Home");
        }
    }
}