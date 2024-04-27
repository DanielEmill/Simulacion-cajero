using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class BancoBLL
{
    private Contexto _contexto;

    public BancoBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int bancoId)
    {
        return _contexto.banco.Any(b => b.Id == bancoId);
    }

    private bool Insertar(Bank banco)
    {
        _contexto.banco.Add(banco);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Bank banco)
    {
        _contexto.Entry(banco).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Bank banco)
    {
        if (!Existe(banco.Id))
        {
            return this.Insertar(banco);
        }
        else
        {
            return this.Modificar(banco);
        }
    }
    public bool Eliminar(Bank banco)
    {
        if (banco == null)
        {
            return false;
        }

        try
        {
            _contexto.Entry(banco).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        catch (Exception ex)
        {

            return false; // Indicar que la eliminación no tuvo éxito
        }
    }

    public Bank Buscar(int bancoId)
    {
        return _contexto.banco
          .Include(b => b.Transacciones)
          .Where(b => b.Id == bancoId)
          .AsTracking()
          .SingleOrDefault();
    }

    public List<Bank> GetList(Expression<Func<Bank, bool>> criterio)
    {
        return _contexto.banco.AsNoTracking().Where(criterio).ToList();
    }
}