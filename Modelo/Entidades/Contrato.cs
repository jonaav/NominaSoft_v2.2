using System;
using System.Collections.Generic;

namespace Modelo.Entidades
{
    public partial class Contrato
    {
        public Contrato()
        {
            BoletaPago = new HashSet<BoletaPago>();
            ConceptosDePago = new HashSet<ConceptosDePago>();
        }

        public int IdContrato { get; set; }
        public bool AsignacionFamiliar { get; set; }
        public string Cargo { get; set; }
        public int Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int HorasSemanales { get; set; }
        public int IdAfp { get; set; }
        public int IdEmpleado { get; set; }
        public decimal ValorHora { get; set; }

        public Afp Afp { get; set; }
        public Empleado Empleado{ get; set; }
        public ICollection<BoletaPago> BoletaPago { get; set; }
        public ICollection<ConceptosDePago> ConceptosDePago { get; set; }


        //R01 contrato
        public Boolean ValidarVigenciaContrato()
        {
            Boolean vigente = false;
            //estado anulado = 0
            if (FechaFin >= DateTime.Today && Estado != 0)
            {
                vigente = true;
            }
            return vigente;
        }

        //R02 contrato
        public Boolean ValidarFechaInicioNuevoContrato(DateTime fechaContratoAnterior)
        {
            if (FechaInicio > fechaContratoAnterior)
            {
                return true;
            }

            return false;
        }

        //R03 contrato
        public Boolean ValidarFechaFinNuevoContrato()
        {
            if (FechaFin>FechaInicio)
            {
                if ((((FechaFin.Year * 365) + (FechaFin.Month * 30) + FechaFin.Day) - ((FechaInicio.Year * 365) + (FechaInicio.Month * 30) + FechaInicio.Day)) >= 90 &&
                    (((FechaFin.Year * 365) + (FechaFin.Month * 30) + FechaFin.Day) - ((FechaInicio.Year * 365) + (FechaInicio.Month * 30) + FechaInicio.Day)) <= 365)
                    return true;
            }
            return false;
        }


        //R04 contrato
        public Boolean ValidarHorasContratadas()
        {
            if (HorasSemanales >= 8 && HorasSemanales <= 40)
            {
                return true;
            }
            return false;
        }

        //R05 contrato
        public Boolean ValidarValorHora(string gradoAcademico)
        {
            if (gradoAcademico == "primaria" || gradoAcademico == "secundaria")
            {
                if (ValorHora >= 5 && ValorHora <= 10)
                    return  true;
            }
            else if (gradoAcademico == "bachiller")
            {
                if (ValorHora >= 11 && ValorHora <= 20)
                    return  true;
            }
            else if (gradoAcademico == "profesional")
            {
                if (ValorHora >= 21 && ValorHora <= 30)
                    return  true;
            }
            else if (gradoAcademico == "magister")
            {
                if (ValorHora >= 31 && ValorHora <= 40)
                    return  true;
            }
            else if (gradoAcademico == "doctor")
            {
                if (ValorHora >= 41 && ValorHora <= 60)
                    return  true;
            }

            return false;
        }

        //R03 pagos
        public decimal CalcularAsignacionFamiliar()
        {
            decimal asignacion = 0;
            decimal sueldoMinimo = 930;

            if (AsignacionFamiliar)
                asignacion = sueldoMinimo/10;

            return asignacion;
        }
    }
}
