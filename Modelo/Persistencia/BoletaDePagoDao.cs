using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public class BoletaDePagoDao: IBoletaDePagoDao
    {
        private readonly DBNominaSoftContext _context;

        public BoletaDePagoDao(DBNominaSoftContext context)
        {
            _context = context;
        }

        public void RegistrarBoletaDePago(BoletaPago boleta)
        {
            try
            {
                _context.BoletaPago.Add(boleta);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        } 




    }
}
