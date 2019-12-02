using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public interface IBoletaDePagoDao
    {
        void RegistrarBoletaDePago(BoletaPago boleta);
    }
}
