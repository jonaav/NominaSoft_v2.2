using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public class ContratoDao: IContratoDao
    {
        private readonly DBNominaSoftContext _context;

        public ContratoDao(DBNominaSoftContext context)
        {
            _context = context;
        }

        public List<Contrato> ListarContratosDeEmpleado(Empleado empleado)
        {
            try
            {
                List<Contrato> contratos = (from c in _context.Contrato
                                            join e in _context.Empleado on c.Empleado.Dni equals e.Dni
                                            where c.Empleado.Dni == empleado.Dni
                                            select new Contrato
                                            {
                                                IdContrato = c.IdContrato,
                                                FechaInicio = c.FechaInicio,
                                                FechaFin = c.FechaFin,
                                                Cargo = c.Cargo,
                                                Estado = c.Estado,
                                                Afp = c.Afp,
                                                AsignacionFamiliar = c.AsignacionFamiliar,
                                                HorasSemanales = c.HorasSemanales,
                                                ValorHora = c.ValorHora
                                            }).ToList();

                return contratos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Contrato> ListarContratosPoPeriodo(PeriodoPago periodo)
        {
            try
            {
                List<Contrato> contratos = (from c in _context.Contrato

                                            where (c.FechaFin >= periodo.FechaInicio &&
                                                    c.FechaInicio <= periodo.FechaInicio &&
                                                    c.Estado == 1
                                            )
                                            select new Contrato
                                            {
                                                IdContrato = c.IdContrato,
                                                FechaInicio = c.FechaInicio,
                                                FechaFin = c.FechaFin,
                                                Cargo = c.Cargo,
                                                Afp = c.Afp,
                                                AsignacionFamiliar = c.AsignacionFamiliar,
                                                HorasSemanales = c.HorasSemanales,
                                                ValorHora = c.ValorHora,
                                                IdEmpleado = c.IdEmpleado
                                            }).ToList();

                return contratos;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //REFACT 2.0
        public Contrato BuscarUltimoContratoDelEmpleado(int idEmpleado)
        {
            Contrato ultimoContrato = new Contrato();

            var query = from c in _context.Contrato
                        where c.IdEmpleado == idEmpleado
                        select c;

            ultimoContrato = query.OrderByDescending(o => o.IdContrato).Where(
                o => o.Estado != 0).Take(1).FirstOrDefault();
            return ultimoContrato;
        }

        public void RegistrarContrato(Contrato contrato)
        {
            try
            {
                contrato.Estado = 1;
                _context.Contrato.Add(contrato);
                _context.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            }
        }

        public Empleado BuscarEmpleadoDeUnContrato(int id)
        {
            Contrato contrato = (from c in _context.Contrato
                                    join e in _context.Empleado on c.Empleado.IdEmpleado equals e.IdEmpleado
                                    where c.IdContrato == id
                                    select new Contrato
                                    {
                                        Empleado = c.Empleado
                                    }).FirstOrDefault();
            return contrato.Empleado;
        }

        public void EditarContrato(Contrato contrato)
        {
            try
            {
                _context.Contrato.Attach(contrato);
                _context.Contrato.Update(contrato);
                _context.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            }
        }

        public Contrato BuscarContratoID(int id)
        {
            Contrato contrato = _context.Contrato.FirstOrDefault(x => x.IdContrato == id);
            return contrato;
        }

        public void EliminarContrato(Contrato contrato)
        {
            try
            {
                contrato = BuscarContratoID(contrato.IdContrato);
                contrato.Estado = 0;
                _context.Contrato.Attach(contrato);
                _context.Contrato.Update(contrato);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }







    }
}
