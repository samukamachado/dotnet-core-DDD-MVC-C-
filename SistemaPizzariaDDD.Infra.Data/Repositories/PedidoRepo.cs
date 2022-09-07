using SistemaPizzariaDDD.Domain.Models;

namespace SistemaPizzariaDDD.Infra.Data.Repositories;
public class PedidoRepo 
{
    private static string location = "/Users/samuelompereira/Documents/TesteAlphaDDD/src/SistemaPizzariaDDD.Infra.Data/BancoDeDados/BancoDeDados.json";
    private static string json = File.ReadAllText(location);

    public Pedidos RetornarPedidos()
    {
        try
        {
            Pedidos pedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<Pedidos>(json);

            return pedidos;

        }
        catch (System.Exception e)
        {

            throw new Exception(e.Message);
        }

    }
    public void CriarPedido(Pedido pedidoNew)
    {
        try
        {
            long id = 0;
            Pedidos pedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<Pedidos>(json);

            id = pedidos.pedidos.Count + 1;

            pedidos.pedidos.Add(new Pedido(id, pedidoNew.NomeCliente, pedidoNew.Email, pedidoNew.PedidoCliente, 0, ""));

            var convertedJson = Newtonsoft.Json.JsonConvert.SerializeObject(pedidos);
            File.WriteAllText(location, convertedJson);


        }
        catch (System.Exception e)
        {
            throw new Exception(e.Message);

        }
    }
    public void AlterarPedido(Pedido pedidoAlterar)
    {
        try
        {
            Pedidos pedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<Pedidos>(json);

            pedidos.pedidos.Where(w => w.Id == pedidoAlterar.Id).ToList().ForEach(s => { s.Valor = pedidoAlterar.Valor; s.Status = pedidoAlterar.Status; });

            var convertedJson = Newtonsoft.Json.JsonConvert.SerializeObject(pedidos);
            File.WriteAllText(location, convertedJson);

        }
        catch (System.Exception e)
        {
            throw new Exception(e.Message);

        }
    }

    public Pedido RetornaPedidoPorID(int ID)
    {
        try
        {
            Pedidos pedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<Pedidos>(json);
            

            var pedidoCliente = pedidos.pedidos.FirstOrDefault(o => o.Id == ID);

            return pedidoCliente;

        }
        catch (System.Exception e)
        {

            throw new Exception(e.Message);
        }

    }

}
