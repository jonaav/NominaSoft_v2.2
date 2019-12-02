using System;
using System.Collections.Generic;

namespace Modelo.Entidades
{
    public partial class PeriodoPago
    {
        //public PeriodoPago()
        //{
        //    BoletaPago = new HashSet<BoletaPago>();
        //    ConceptosDePago = new HashSet<ConceptosDePago>();
        //}

        public int IdPeriodoPago { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        //public ICollection<BoletaPago> BoletaPago { get; set; }
        public BoletaPago BoletaPago { get; set; }
        //public ICollection<ConceptosDePago> ConceptosDePago { get; set; }
        public ConceptosDePago ConceptosDePago { get; set; }

        #region metodos
        public int CalcularTotalSemanas()
        {
            return Convert.ToInt32((FechaFin - FechaInicio).Days / 7);
        }

        public Boolean ValidarPeriodoActivo()
        {
            Boolean valido = false;
            if (DateTime.Today >= FechaFin)
            {
                valido = true;
            }
            return valido;
        }

        #endregion metodos
    }
}
