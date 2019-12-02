using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Modelo.Entidades;
using Modelo.Persistencia;

namespace Modelo.Services
{
    public class BoletaDePagoServiceImpl : IBoletaDePagoService
    {
        private readonly IBoletaDePagoDao _boletaDePagoDao;
        private readonly IConceptosDePagoDao _conceptosDePagoDao;
        private readonly IContratoDao _contratoDao;
        private readonly IEmpleadoDao _empleadoDao;

        public BoletaDePagoServiceImpl(
            IBoletaDePagoDao boletaDePagoDao, 
            IConceptosDePagoDao conceptosDePagoDao,
            IContratoDao contratoDao,
            IEmpleadoDao empleadoDao
        )
        {
            _boletaDePagoDao = boletaDePagoDao;
            _conceptosDePagoDao = conceptosDePagoDao;
            _contratoDao = contratoDao;
            _empleadoDao = empleadoDao;
        }

        public List<BoletaPago> GenerarBoletasDePago(List<Contrato> contratosPeriodo, PeriodoPago periodoPago)
        {
            List<BoletaPago> listaBoletasDePago = new List<BoletaPago>();
            foreach (Contrato contrato in contratosPeriodo)
            {
                ConceptosDePago conceptosDePago = _conceptosDePagoDao.BuscarConceptosDePagoPorContratoYPeriodo(contrato, periodoPago);
                BoletaPago boleta = new BoletaPago
                {
                    AsignacionFamiliar = contrato.CalcularAsignacionFamiliar(),
                    Fecha = DateTime.Today,
                    ValorHoras = contrato.ValorHora,
                    IdContrato = contrato.IdContrato,
                    IdPeriodoPago = periodoPago.IdPeriodoPago,
                    IdConceptosDePago = conceptosDePago.IdConceptosDePago
                };
                _boletaDePagoDao.RegistrarBoletaDePago(boleta);
                boleta.Contrato = _contratoDao.BuscarContratoID(contrato.IdContrato);
                boleta.Contrato.Empleado = _contratoDao.BuscarEmpleadoDeUnContrato(boleta.Contrato.IdContrato);
                boleta.TotalHoras = boleta.CalcularTotalHoras();
                listaBoletasDePago.Add(boleta);
            }
            return listaBoletasDePago;
        }
    }
}
