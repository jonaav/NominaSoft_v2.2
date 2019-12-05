using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public class PeriodoDePagoDao: IPeriodoDePagoDao
    {
        private readonly DBNominaSoftContext _context;

        public PeriodoDePagoDao(DBNominaSoftContext context)
        {
            _context = context;
        }


        public List<PeriodoPago> ListarPeriodos()
        {
            try
            {
                return _context.PeriodoPago.Where(p => p.Estado == 1).ToList();
            }catch(Exception e)
            {
                throw e;
            }
        }

        public PeriodoPago BuscarPeriodoID(int idPeriodo)
        {
            try
            {
                return _context.PeriodoPago.Where(c => c.IdPeriodoPago == idPeriodo).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PeriodoPago BuscarPeriodoActual()
        {
            DateTime fechaActual = DateTime.Today;
            try
            {
                return _context.PeriodoPago.Where(c => c.FechaFin <= fechaActual && 
                                                    c.Estado == 1
                                                 ).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CerrarPeriodo(PeriodoPago periodo)
        {
            try
            {
                periodo.Estado = 2;
                _context.PeriodoPago.Attach(periodo);
                _context.PeriodoPago.Update(periodo);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int CantidadPeriodosActivos()
        {
            try
            {
                return (from p in _context.PeriodoPago
                        where p.Estado == 1
                        select p).Count();
            }
            catch (Exception e)
            {
                throw e;
            }
        }











    }
}
