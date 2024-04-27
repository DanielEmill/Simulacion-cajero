
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;


    public class TransaccionesBLL
	{
        private Contexto _contexto;

        public TransaccionesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int transaccionId)
        {
            return _contexto.transacciones.Any(t => t.Id == transaccionId);
        }

        private bool Insertar(Transaccion transaccion)
        {
            _contexto.transacciones.Add(transaccion);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Transaccion transaccion)
        {
            _contexto.Entry(transaccion).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Transaccion transaccion)
        {
            if (!Existe(transaccion.Id))
            {
                return Insertar(transaccion);
            }
            else
            {
                return Modificar(transaccion);
            }
        }

    public bool Eliminar(Transaccion transaccion)
    {
        if (transaccion == null)
        {
            return false;
        }

        try
        {
            _contexto.Entry(transaccion).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        catch (Exception ex)
        {

            return false;
        }
    }

    public Transaccion Buscar(int transaccionId)
        {
            return _contexto.transacciones
                .Where(t => t.Id == transaccionId)
                .AsTracking()
                .SingleOrDefault();
        }
        public List<Transaccion> GetList(Expression<Func<Transaccion, bool>> criterio)
        {
            return _contexto.transacciones.AsNoTracking().Where(criterio).ToList();
        }
    }
