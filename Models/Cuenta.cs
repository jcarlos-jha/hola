using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pruebaTecnica1.Models
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuentaId { get; set; }        
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; } = true;
        public Cliente Cliente { get; set; }
    }
}
