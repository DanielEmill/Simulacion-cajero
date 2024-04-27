using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



public class Contexto : DbContext
{
    public DbSet<Bank> banco{ get; set; }
    public DbSet<Transaccion> transacciones { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
}

