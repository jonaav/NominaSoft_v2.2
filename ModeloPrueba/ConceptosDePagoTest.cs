using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;

namespace ModelPruebas
{
    [TestClass]
    public class ConceptosDePagoTest
    {
        [TestMethod]
        public void Test1_ObtenerSumatoriaDescuentos()
        {

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoHorasAusente = 20,
                TotalAdelantos = 30,
                OtrosDescuentos = 10
            };
            
            decimal res_Esperado = 60;
            decimal res_Obtenido = conceptosDePago.ObtenerSumatoriaDescuentos();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test1_ObtenerSumatoriaIngresos()
        {

            ConceptosDePago conceptosDePago = new ConceptosDePago
            {
                MontoHorasExtra = 20,
                MontoReintegros = 30,
                OtrosIngresos = 20
            };

            decimal res_Esperado = 70;
            decimal res_Obtenido = conceptosDePago.ObtenerSumatoriaIngresos();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }
    }
}
