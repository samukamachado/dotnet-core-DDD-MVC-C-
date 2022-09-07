using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaPizzariaDDD.Web.Models;
using SistemaPizzariaDDD.Application;
using SistemaPizzariaDDD.Domain.Models;

namespace SistemaPizzariaDDD.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        PedidosService service = new PedidosService();
        Pedidos pedidos = new Pedidos();

        var pedidosList = new List<PedidoClienteModel>();
        pedidos = service.RetornarPedidos();

        foreach (var item in pedidos.pedidos)
        {
            PedidoClienteModel model = new PedidoClienteModel();
            model.NomeCliente = item.NomeCliente;
            model.PedidoCliente = item.PedidoCliente;
            model.Email = item.Email;
            model.Id = item.Id;

            pedidosList.Add(model);

        }

        return View(pedidosList);
    }

    public IActionResult PedidoCliente()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

  
    public ActionResult Atualizar(int Id)
    {


        return RedirectToAction("Index");
    }

}
