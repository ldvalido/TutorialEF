using System.ComponentModel.DataAnnotations.Schema;

namespace EFCFBanco.DataModel
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string CBU { get; set; }
        public double Saldo { get; set; }
        public int ClienteID { get; set; }

        [ForeignKey("ClienteID")]
        public Cliente Cliente { get; set; }
    }
}
