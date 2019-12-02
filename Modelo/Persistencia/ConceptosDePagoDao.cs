using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public class ConceptosDePagoDao: IConceptosDePagoDao
    {
        private readonly DBNominaSoftContext _context;

        public ConceptosDePagoDao(DBNominaSoftContext context)
        {
            _context = context;
        }


        public ConceptosDePago BuscarConceptosDePagoPorContratoYPeriodo(Contrato contrato, PeriodoPago periodo)
        {
            try
            {
                ConceptosDePago conceptosDePago = _context.ConceptosDePago.Where(c => c.IdContrato == contrato.IdContrato &&
                                                                                    c.IdPeriodoPago == periodo.IdPeriodoPago
                                                                                ).FirstOrDefault();
                return conceptosDePago;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
