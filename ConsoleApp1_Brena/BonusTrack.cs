using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Brena
{
    public class BonusTrack
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();

        public static void PedidosEntreFechas(String fechaInicial, String fechaFin)
        {
            var pedidos = context.clientes      
                .Join(context.Pedidos.Where(fecha => fecha.FechaPedido >= Convert.ToDateTime(fechaInicial) 
                        && fecha.FechaPedido <= Convert.ToDateTime(fechaFin)),
                        cliente => cliente.idCliente,
                        pedido => pedido.IdCliente,
                       (cliente, pedido) => new { Cliente = cliente, Pedido = pedido }).
               Join(context.detallesdepedidos,
               dPedido => dPedido.Pedido.IdPedido,
               dsPedido => dsPedido.idpedido,
               (dPedido, dsPedido) => new { dPedido.Pedido , dPedido.Cliente, detallePedido = dsPedido.idpedido }).
               Sum(can => can.Pedido.)
               GroupBy(client => client.Cliente, dtPedido => dtPedido.detallePedido).
 
               Select(x => new
               {
                    NombreComapania= x.uir.NombreCompañia,
                    CantidadPedido = x.u.IdPedido
               });
            
        }

    }
}
