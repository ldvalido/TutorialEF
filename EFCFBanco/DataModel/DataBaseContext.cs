using System.Data.Entity;

namespace EFCFBanco.DataModel
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DataBaseContext() : base("BancoModeloContainer")
        { }
    }
}
