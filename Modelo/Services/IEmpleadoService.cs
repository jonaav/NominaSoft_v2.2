using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Modelo.Services
{
    public interface IEmpleadoService
    {
        List<Empleado> ListaEmpleados();

        Empleado BuscarEmpleadoDNI(string dni);
        Empleado BuscarEmpleadoPorID(int id);
    }
}
