using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public interface IPeriodoDePagoDao
    {
        List<PeriodoPago> ListarPeriodos();
        PeriodoPago BuscarPeriodoID(int idPeriodo);
        PeriodoPago BuscarPeriodoActual();
        void CerrarPeriodo(PeriodoPago periodo);
        int CantidadPeriodosActivos();
    }
}
