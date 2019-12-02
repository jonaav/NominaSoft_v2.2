using System;
using System.Collections.Generic;

namespace Modelo.Entidades
{
    public partial class ConceptosDePago
    {
        public ConceptosDePago()
        {
            BoletaPago = new HashSet<BoletaPago>();
        }

        public int IdConceptosDePago { get; set; }
        public decimal MontoHorasAusente { get; set; }
        public decimal MontoHorasExtra { get; set; }
        public decimal MontoReintegros { get; set; }
        public decimal OtrosDescuentos { get; set; }
        public decimal OtrosIngresos { get; set; }
        public decimal TotalAdelantos { get; set; }
        public int IdContrato { get; set; }
        public int IdPeriodoPago { get; set; }

        public Contrato Contrato { get; set; }
        public PeriodoPago PeriodoPago { get; set; }
        public ICollection<BoletaPago> BoletaPago { get; set; }


        public decimal ObtenerSumatoriaDescuentos()
        {
            return MontoHorasAusente + TotalAdelantos + OtrosDescuentos;
        }
        public decimal ObtenerSumatoriaIngresos()
        {
            return MontoHorasExtra + MontoReintegros + OtrosIngresos;
        }
    }
}
