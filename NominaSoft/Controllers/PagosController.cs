using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelo.Entidades;
using Modelo.Services;
using Newtonsoft.Json;

namespace NominaSoft.Controllers
{
    public class PagosController : Controller
    {

        private readonly IPeriodoDePagoService _periodoDePagoService;
        private readonly IContratoService _contratoService;
        private readonly IBoletaDePagoService _boletaDePagoService;

        public PagosController(
            IPeriodoDePagoService periodoDePagoService, 
            IContratoService contratoService, 
            IBoletaDePagoService boletaDePagoService
        ){
            _periodoDePagoService = periodoDePagoService;
            _contratoService = contratoService;
            _boletaDePagoService = boletaDePagoService;
        }

        public IActionResult GestionarPago()
        {
            PeriodoPago periodoDePago = _periodoDePagoService.BuscarPeriodoActual();
            ViewBag.PeriodoDePago = periodoDePago;
            ViewBag.ListarBoletas = null;
            return View();
        }

        [HttpPost]
        public IActionResult GestionarPago(int idPeriodo)
        {
            PeriodoPago periodo = _periodoDePagoService.BuscarPeriodoID(idPeriodo);
            List<Contrato> contratosPeriodo = _contratoService.ListarContratosPoPeriodo(periodo);
            List<BoletaPago> boletas=null;
            if (contratosPeriodo != null)
            {
                boletas = _boletaDePagoService.GenerarBoletasDePago(contratosPeriodo, periodo);
                _periodoDePagoService.CerrarPeriodo(periodo);
            }
            PeriodoPago periodoDePago = _periodoDePagoService.BuscarPeriodoActual();
            ViewBag.PeriodoDePago = periodoDePago;
            ViewBag.ListarBoletas = boletas;
            return View();
        }

        [HttpPost]
        public IActionResult DevolverPeriodo(int idPeriodo)
        {
            return Json( _periodoDePagoService.BuscarPeriodoID(idPeriodo));
        }

        [HttpGet]
        public IActionResult DevolverPeriodoActual()
        {
           
            return Json(_periodoDePagoService.BuscarPeriodoActual());
        }

        [HttpGet]
        public IActionResult DevolverTotalPeriodosActivos()
        {
            return Json(_periodoDePagoService.CantidadPeriodosActivos());
        }

        public IActionResult ValidarFechaPermitidaParaProcesarPagos(int idPeriodo)
        {
            return Json(_periodoDePagoService.BuscarPeriodoID(idPeriodo).ValidarPeriodoActivo());
        }

    }


}