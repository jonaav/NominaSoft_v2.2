using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Modelo.Persistencia;

namespace Modelo.Services
{
    public class EmpleadoServiceImpl : IEmpleadoService
    {
        private readonly IEmpleadoDao _empleadoDao;

        public EmpleadoServiceImpl(IEmpleadoDao empleadoDao)
        {
            _empleadoDao = empleadoDao;
        }
        public List<Empleado> ListaEmpleados()
        {
            try
            {
                List<Empleado> listaEmpleados = _empleadoDao.ListaEmpleados();
                return listaEmpleados;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public Empleado BuscarEmpleadoDNI(string dni)
        {
            Empleado empleado = null;
            try
            {
                empleado = _empleadoDao.BuscarEmpleadoDNI(dni); 
                return empleado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Empleado BuscarEmpleadoPorID(int id)
        {
            Empleado empleado = null;
            try
            {
                empleado = _empleadoDao.BuscarEmpleadoPorID(id);
                return empleado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
