using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCFBanco.DataModel
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }

        //public DataBaseContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCFBanco.DataModel.DataBaseContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        //{

        //}

    }
}
