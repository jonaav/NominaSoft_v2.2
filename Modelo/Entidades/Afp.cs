using System;
using System.Collections.Generic;

namespace Modelo.Entidades
{
    public partial class Afp
    {
        public Afp()
        {
            Contrato = new HashSet<Contrato>();
        }

        public int IdAfp { get; set; }
        public string Descripcion { get; set; }
        public decimal PorcentajeDescuento { get; set; }

        public ICollection<Contrato> Contrato { get; set; }
    }
}
