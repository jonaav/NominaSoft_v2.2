using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Modelo.Persistencia;

namespace Modelo.Services
{
    public class ContratoServiceImpl : IContratoService
    {
        private readonly IEmpleadoDao _empleadoDao;
        private readonly IContratoDao _contratoDao;

        public ContratoServiceImpl(
            IEmpleadoDao empleadoDao, 
            IContratoDao contratoDao
        ){
            _empleadoDao = empleadoDao;
            _contratoDao = contratoDao;
        }

        public List<Contrato> ListarContratos(Empleado empleado)
        {
            try
            {
                List<Contrato> contratos = _contratoDao.ListarContratosDeEmpleado(empleado);

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
                if (periodo.ValidarPeriodoActivo())
                {
                    List<Contrato> contratos = _contratoDao.ListarContratosPoPeriodo(periodo);
                    return contratos;
                }
                else {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Contrato BuscarUltimoContratoDelEmpleado(int id)
        {
            Contrato ultimoContrato = _contratoDao.BuscarUltimoContratoDelEmpleado(id);
            return ultimoContrato;
        }

        private bool ValidacionConRespectoAlUltimoContrato(Contrato ultimoContrato, Contrato contrato)
        {
            if (ultimoContrato.ValidarVigenciaContrato() ||
                !contrato.ValidarFechaInicioNuevoContrato(ultimoContrato.FechaFin))
                return false;

            return true;
        }

        private bool ValidarDatosDelNuevoContrato(Contrato contrato)
        {
            if (contrato.ValidarFechaFinNuevoContrato() &&
                contrato.ValidarHorasContratadas() &&
                contrato.ValidarValorHora(contrato.Empleado.GradoAcademico))
                return true;
            return false;
        }

        public bool RegistrarContrato(Contrato contrato)
        {
            contrato.Empleado = _empleadoDao.BuscarEmpleadoPorID(contrato.IdEmpleado);
            Contrato ultimoContrato = _contratoDao.BuscarUltimoContratoDelEmpleado(contrato.IdEmpleado);

            if (ultimoContrato != null)
                if (!ValidacionConRespectoAlUltimoContrato(ultimoContrato, contrato)) return false;

            if (ValidarDatosDelNuevoContrato(contrato))
            {
                contrato.Estado = 1;
                _contratoDao.RegistrarContrato(contrato);
                return true;
            }
            return false;
        }


        public bool EditarContrato(Contrato contrato)
        {
            contrato.Empleado = _empleadoDao.BuscarEmpleadoPorID(contrato.IdEmpleado);

            if (contrato.ValidarFechaFinNuevoContrato())
            {
                if (contrato.ValidarHorasContratadas())
                {
                    if (contrato.ValidarValorHora(contrato.Empleado.GradoAcademico))
                    {
                        _contratoDao.EditarContrato(contrato);
                        return true;
                    }
                }
            }

            return false;
        }



        public void EliminarContrato(Contrato contrato)
        {
            _contratoDao.EliminarContrato(contrato);
        }


        public int CantidadContratosVigentes()
        {
            int cantidadContratosVigentes = 0;
            List<Empleado> listaEmpleados = _empleadoDao.ListaEmpleados();
            foreach(Empleado empleado in listaEmpleados)
            {
                foreach(Contrato contrato in _contratoDao.ListarContratosDeEmpleado(empleado))
                {
                    if(contrato.ValidarVigenciaContrato())
                    {
                        cantidadContratosVigentes++;
                    }
                }
            }
            return cantidadContratosVigentes;
        }

    }
}
