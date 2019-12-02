using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Modelo.Entidades;
using Modelo.Persistencia;

namespace Modelo.Services
{
    public class PeriodoDePagoServiceImpl :IPeriodoDePagoService
    {
        private readonly IPeriodoDePagoDao _periodoDePagoDao;

        public PeriodoDePagoServiceImpl(IPeriodoDePagoDao periodoDePagoDao)
        {
            _periodoDePagoDao = periodoDePagoDao;
        }

        public List<PeriodoPago> ListarPeriodos()
        {
            return _periodoDePagoDao.ListarPeriodos();
        }

        public PeriodoPago BuscarPeriodoID(int idPeriodo)
        {
            return _periodoDePagoDao.BuscarPeriodoID(idPeriodo);
        }

        public PeriodoPago BuscarPeriodoActual()
        {
            return _periodoDePagoDao.BuscarPeriodoActual();
        }

        public void CerrarPeriodo(PeriodoPago periodo)
        {
            _periodoDePagoDao.CerrarPeriodo(periodo);
        }

        public int CantidadPeriodosActivos()
        {
            return _periodoDePagoDao.CantidadPeriodosActivos();
        }
    }
}
