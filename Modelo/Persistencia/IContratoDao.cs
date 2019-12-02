using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public interface IContratoDao
    {
        List<Contrato> ListarContratosDeEmpleado(Empleado empleado);
        List<Contrato> ListarContratosPoPeriodo(PeriodoPago periodo);
        Contrato BuscarUltimoContratoDelEmpleado(int idEmpleado);
        Empleado BuscarEmpleadoDeUnContrato(int id);
        void RegistrarContrato(Contrato contrato);
        void EditarContrato(Contrato contrato);
        Contrato BuscarContratoID(int id);
        void EliminarContrato(Contrato contrato);
    }
}
