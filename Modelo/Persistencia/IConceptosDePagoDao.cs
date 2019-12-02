using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public interface IConceptosDePagoDao
    {
        ConceptosDePago BuscarConceptosDePagoPorContratoYPeriodo(Contrato contrato, PeriodoPago periodo);
    }
}
