using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPizzariaDDD.Domain.Models;
using SistemaPizzariaDDD.Infra.Data.Repositories;

namespace SistemaPizzariaDDD.Application;

public class PedidosService
{

    public void CriarPedido(Pedido pedido)
    {
        PedidoRepo repo = new PedidoRepo();
        repo.CriarPedido(pedido);
    }

    public void AlterarPedido(Pedido pedidoAlterado)
    {
        PedidoRepo repo = new PedidoRepo();
        repo.AlterarPedido(pedidoAlterado);

    }

    public Pedidos RetornarPedidos()
    {
        PedidoRepo repo = new PedidoRepo();
        return repo.RetornarPedidos();

    }

    public Pedido RetornaPedidoPorID(int ID)
    {
        PedidoRepo repo = new PedidoRepo();
        return repo.RetornaPedidoPorID(ID);
    }
}



