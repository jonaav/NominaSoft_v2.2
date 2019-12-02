using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entidades;

namespace Modelo.Services
{
    public interface IContratoService
    {
        List<Contrato> ListarContratos(Empleado empleado);
        bool RegistrarContrato(Contrato contrato);
        bool EditarContrato(Contrato contrato);
        void EliminarContrato(Contrato contrato);
        List<Contrato> ListarContratosPoPeriodo(PeriodoPago periodo);
        int CantidadContratosVigentes();
        Contrato BuscarUltimoContratoDelEmpleado(int idEmpleado);

    }
}
