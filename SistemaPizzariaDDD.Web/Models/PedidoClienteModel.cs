using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPizzariaDDD.Web.Models
{
    public class PedidoClienteModel
    {

        public long Id { get; set; }
        public string ?NomeCliente { get; set; }
        public string ?Email { get; set; }
        public string ?PedidoCliente { get; set; }
        public double Valor { get; set; }
        public string? Status { get; set; }

    }
}