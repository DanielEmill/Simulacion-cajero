using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


    public class Transaccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int IdBanco { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required]
        public TipoTransaccion Tipo { get; set; }

        [StringLength(255)]
        public string Detalle { get; set; }

        [ForeignKey("IdBanco")]
        public Bank banco { get; set; }

    public Transaccion()
    {
        Fecha = DateTime.Now;
    }
}

    public enum TipoTransaccion
    {
        Deposito,
        Retiro
    }
