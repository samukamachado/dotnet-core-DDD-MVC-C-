using System.Collections;
using System.Collections.Generic;

namespace SistemaPizzariaDDD.Domain.Models;
public class Pedido
{

    public Pedido(long id, string nomeCliente, string email, string pedidoCliente, double valor, string status)
    {
        ValidaPedido(nomeCliente, email, pedidoCliente);
        Id = id;
        NomeCliente = nomeCliente;
        Email = email;
        PedidoCliente = pedidoCliente;
        Valor = valor;
        Status = status;

    }
    

    public long Id { get; private set; }
    public string ?NomeCliente { get; private set; }
    public string ?Email { get; private set; }
    public string ?PedidoCliente { get; private set; }
    public double Valor { get; set; }
    public string ?Status { get; set; }

    private void ValidaPedido(string nome, string email, string pedidoCliente)
    {
        if (string.IsNullOrEmpty(nome))
            throw new InvalidOperationException("O nome é inválido");

        if (string.IsNullOrEmpty(email))
            throw new InvalidOperationException("O email é inválido");

        if (string.IsNullOrEmpty(pedidoCliente))
            throw new InvalidOperationException("O pedido é inválido");
    }

}

public class Pedidos
{
    public List<Pedido> pedidos { get; set; }
}


