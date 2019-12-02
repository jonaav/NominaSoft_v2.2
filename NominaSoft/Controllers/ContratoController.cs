using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Modelo.Entidades;
using Modelo.Services;

namespace NominaSoft.Controllers
{
    public class ContratoController : Controller
    {
        private readonly IContratoService _contratoService;
        private readonly IEmpleadoService _empleadoService;

        public ContratoController(IContratoService contratoService, IEmpleadoService empleadoService)
        {
            _contratoService = contratoService;
            _empleadoService = empleadoService;
        }
        #region metodos
        [HttpGet]
        public IActionResult GestionarContrato(string dni)
        {
            Contrato contrato = new Contrato
            {
                Empleado = _empleadoService.BuscarEmpleadoDNI(dni)
            };

            List<Contrato> contratos = _contratoService.ListarContratos(contrato.Empleado);
            ViewBag.Contratos = contratos;
            return View(contrato);
        }

        [HttpPost]
        public IActionResult Guardar(Contrato contrato)
        {
            bool registroCompletado = _contratoService.RegistrarContrato(contrato);
            if (registroCompletado)
            {
                return Json("Contrato guardado");
            }
            else
            {
                return Json("");
            }
        }

        [HttpGet]
        public IActionResult BuscarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEmpleado(string dni)
        {
            if (_empleadoService.BuscarEmpleadoDNI(dni) != null)
            {
                return Json(dni);
            }
            else
            {
                return Json("");
            }
        }

        [HttpPost]
        public IActionResult BuscarContratoVigente(int idEmpleado)
        {
            Contrato contrato = _contratoService.BuscarUltimoContratoDelEmpleado(idEmpleado);
            if (contrato != null)
            {
                return Json(contrato);
            }
            else
            {
                return Json("");
            }
        }

        [HttpPost]
        public IActionResult Buscar(Contrato contrato)
        {
            if (!ModelState.IsValid)
                return View("BuscarEmpleado", contrato);
            contrato.Empleado = _empleadoService.BuscarEmpleadoDNI(contrato.Empleado.Dni);
            if (contrato.Empleado != null)
                return RedirectToAction("GestionarContrato", contrato);
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Contrato contrato)
        {
            bool registroCompletado = _contratoService.EditarContrato(contrato);
            if (registroCompletado)
            {
                _contratoService.EditarContrato(contrato);
                return Json("Contrato Editado");
            }
            else
            {
                return View(contrato);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Contrato contrato)
        {
            _contratoService.EliminarContrato(contrato);
            return Json("Eliminado");
        }

        [HttpGet]
        public IActionResult CantidadContratosVigentes()
        {
             return Json(_contratoService.CantidadContratosVigentes());
        }

        #endregion metodos
    }
}
