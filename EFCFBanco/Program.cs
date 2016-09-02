using EFCFBanco.DataModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace EFCFBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataBaseContext())
            {
                Console.Write("Ingrese el nombre de un Cliente: ");
                var nom = Console.ReadLine();
                Console.Write("Ingrese el Direccion de un Cliente: ");
                var dir = Console.ReadLine();
                Console.Write("Ingrese el Email de un cliente: ");
                var email = Console.ReadLine();
                var cliente = new Cliente { Nombre = nom,  Direccion = dir, Email=email};
                db.Clientes.Add(cliente);
                db.SaveChanges();

                // Mostrando los clientes 
                var query = from b in db.Clientes
                            orderby b.Nombre
                            select b;

                Console.WriteLine("Todos los clientes:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Nombre);
                }

                Console.Write("Ingrese CBU de la cuenta:");
                var cbu = Console.ReadLine();

                Console.Write("Ingrese saldo de la cuenta: ");
                var saldo = Console.ReadLine();

                var cuenta = new Cuenta { CBU = cbu, Saldo = double.Parse(saldo), Cliente = cliente };

                cliente.CuentasCliente = new Collection<Cuenta> {cuenta};
                db.Cuentas.Add(cuenta);

                db.SaveChanges();

                // Mostrar cuentas para un cliente especifico en la BD
                Console.Write("Ingrese id del cliente a mostrar: ");
                
                var idCliente = int.Parse(Console.ReadLine());
                var queryCuentasCliente = from c in db.Cuentas
                                          join cl in db.Clientes on c.ClienteID equals cl.ClienteId
                                          where c.ClienteID == idCliente
                                          select c;

                Console.WriteLine("Todas las cuentas en la BD para el cliente seleccionado:");
                foreach (var item in queryCuentasCliente)
                {
                    Console.WriteLine("CBU: " + item.CBU);

                    Console.Write("Id Cliente: "+ item.ClienteID);
                    Console.Write(" Saldo: " + item.Saldo);
                    Console.WriteLine("\n");
                }

               
            }

            Console.WriteLine("");
            Console.ReadKey();
            

        }
    }
}
