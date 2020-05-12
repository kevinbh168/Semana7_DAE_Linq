using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Brena
{
    public class Program_lamdba
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();

        public static void DataSource()
        {
            var queryAllCustomers = context.clientes.ToList();
            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }    
        
        }

        public static void Filtering()
        {
      
            var queryLondonCustomers = context.clientes.Where(c => c.Ciudad == "Londres").Select(c => c).ToList();

            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }

        }


        public static void Ordering()
        {
        
            var queryLondonCustomers3 = context.clientes.Where(c => c.Ciudad == "Londres").OrderBy(c => c.NombreCompañia).
                Select(c => c).ToList();

            foreach (var item in queryLondonCustomers3)
            {
            
                Console.WriteLine(item.NombreCompañia);
            }
        }

        public static void Grouping()
        {
 

            var queryCustomersByCity = context.clientes.GroupBy(c => c.Ciudad).Select(c => c).ToList();

            foreach (var a in queryCustomersByCity)
            {
                Console.WriteLine(a.Key);
                foreach (clientes c in a)
                {
                    Console.WriteLine(" {0}", c.NombreCompañia);
                }
            }
        }

        static void Grouping2()        {            var custQuery = context.clientes.                GroupBy(c => c.Ciudad)                .Where(c => c.Key.Count() > 2).OrderBy(l => l.Key);            foreach (var item in custQuery)            {                Console.WriteLine(item.Key);            }        }


        public static void Joining()
        {

            var innerJoinQuery = context.clientes.
                Join(context.Pedidos, 
                u => u.idCliente,
                uir => uir.IdCliente,
                (u, uir) => new { u, uir }).
                Select(x => new 
                        {
                    ID = x.u.Region,
                    CustomerName = x.u.NombreCompañia,
                    DistributorName = x.uir.PaisDestinatario
                            });

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }
    }
}
