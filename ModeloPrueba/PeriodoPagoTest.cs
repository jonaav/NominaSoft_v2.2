using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;


namespace ModelPruebas
{
    [TestClass]
    public class PeriodoPagoTest
    {
        [TestMethod]
        public void Test1_CalcularTotalSemanas()
        {

            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaFin = Convert.ToDateTime("30-11-19"),
                FechaInicio = Convert.ToDateTime("01-11-19")
            };

            decimal res_Esperado = 4;
            decimal res_Obtenido = periodoPago.CalcularTotalSemanas();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test1_ValidarPeriodoActivo()
        {

            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaFin = Convert.ToDateTime("10-10-19")
            };

            bool res_Esperado = true;
            bool res_Obtenido = periodoPago.ValidarPeriodoActivo();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarPeriodoActivo()
        {

            PeriodoPago periodoPago = new PeriodoPago
            {
                FechaFin = Convert.ToDateTime("15-10-20")
            };

            bool res_Esperado = false;
            bool res_Obtenido = periodoPago.ValidarPeriodoActivo();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }
    }
}
