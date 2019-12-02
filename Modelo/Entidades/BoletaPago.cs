using System;
using System.Collections.Generic;

namespace Modelo.Entidades
{
    public partial class BoletaPago
    {
        public int IdBoletaPago { get; set; }
        public decimal AsignacionFamiliar { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalHoras { get; set; }
        public decimal ValorHoras { get; set; }
        public int IdContrato { get; set; }
        public int IdPeriodoPago { get; set; }
        public int IdConceptosDePago { get; set; }

        public ConceptosDePago ConceptosDePago { get; set; }
        public Contrato Contrato { get; set; }
        public PeriodoPago PeriodoPago { get; set; }

        #region metodos
        public decimal CalcularDescuentoPorAFP()
        {
            return CalcularSueldoBasico() * (Contrato.Afp.PorcentajeDescuento / 100);
        }

        //R02 pagos
        public decimal CalcularSueldoBasico()
        {
            return CalcularTotalHoras() * Contrato.ValorHora;
        }

        //R07 pagos
        public decimal CalcularSueldoNeto()
        {
            return CalcularTotalDeIngresos() - CalcularTotalDeDescuentos();
        }

        //R04 pagos
        public decimal CalcularTotalDeIngresos()
        {
            return CalcularSueldoBasico() + Contrato.CalcularAsignacionFamiliar() + ConceptosDePago.ObtenerSumatoriaIngresos();
        }

        //R06 pagos
        public decimal CalcularTotalDeDescuentos()
        {
            return CalcularDescuentoPorAFP() + ConceptosDePago.ObtenerSumatoriaDescuentos();
        }

        //R08 pagos
        public decimal CalcularTotalHoras()
        {
            return PeriodoPago.CalcularTotalSemanas() * Contrato.HorasSemanales;
        }


        #endregion metodos
    }
}
