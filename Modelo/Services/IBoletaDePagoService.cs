using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;


namespace Modelo.Services
{
    public interface IBoletaDePagoService
    {
        List<BoletaPago> GenerarBoletasDePago(List<Contrato> contratosPeriodo, PeriodoPago periodoPago);
    }
}
