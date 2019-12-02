using System;
using System.Collections.Generic;

namespace Modelo.Entidades
{
    public partial class Empleado
    {
        public Empleado()
        {
            Contratos = new HashSet<Contrato>();
        }

        public int IdEmpleado { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string GradoAcademico { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}
