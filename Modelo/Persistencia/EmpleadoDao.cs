using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;
using System.Linq;

namespace Modelo.Persistencia
{
    public class EmpleadoDao: IEmpleadoDao
    {
        private readonly DBNominaSoftContext _context;

        public EmpleadoDao(DBNominaSoftContext context)
        {
            _context = context;
        }

        public List<Empleado> ListaEmpleados()
        {
            try
            {
                List<Empleado> listaEmpleados = _context.Empleado.ToList();
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
                empleado = _context.Empleado.FirstOrDefault(x => x.Dni == dni);
            }
            catch (Exception e)
            {
                throw e;
            }
            return empleado;
        }

        public Empleado BuscarEmpleadoPorID(int id)
        {
            Empleado empleado = null;
            try
            {
                empleado = _context.Empleado.FirstOrDefault(x => x.IdEmpleado == id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return empleado;
        }




    }
}
