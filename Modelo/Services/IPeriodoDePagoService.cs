using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;
using System.Threading.Tasks;

namespace Modelo.Services
{
    public interface IPeriodoDePagoService
    {
        List<PeriodoPago> ListarPeriodos();

        PeriodoPago BuscarPeriodoID(int idPeriodo);

        void CerrarPeriodo(PeriodoPago periodo);

        int CantidadPeriodosActivos();
        PeriodoPago BuscarPeriodoActual();
    }
}
