using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public interface IEmpleadoDao
    {
        List<Empleado> ListaEmpleados();
        Empleado BuscarEmpleadoDNI(string dni);
        Empleado BuscarEmpleadoPorID(int id);
    }
}
