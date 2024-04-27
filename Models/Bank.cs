using System.ComponentModel.DataAnnotations;
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroCuenta { get; set; }
        public List<Transaccion> Transacciones { get; set; }
    }
