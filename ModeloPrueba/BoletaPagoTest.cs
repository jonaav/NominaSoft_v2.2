using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;

namespace ModelPruebas
{
    [TestClass]
    public class BoletaPagoTest
    {
        [TestMethod]
        public void Test1_CalcularSueldoBasico()
        {
            Contrato contrato = new Contrato
            {
                ValorHora = 25,
                HorasSemanales = 30
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01-11-2019"),
                FechaFin = Convert.ToDateTime("30-11-2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };
            decimal resEsperado, resObtenido;
            resEsperado = 3000;
            resObtenido = boleta.CalcularSueldoBasico();
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Test1_CalcularDescuentoPorAFP()
        {
            Afp afp = new Afp
            {
                PorcentajeDescuento = 15
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 25,
                HorasSemanales = 30,
                Afp = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01-11-2019"),
                FechaFin = Convert.ToDateTime("30-11-2019")
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };
            decimal resEsperado, resObtenido;
            resEsperado = 450;
            resObtenido = boleta.CalcularDescuentoPorAFP();
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Test1_CalcularTotalDeIngresos()
        {
            Afp afp = new Afp
            {
                PorcentajeDescuento = 15
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 25,
                HorasSemanales = 30,
                AsignacionFamiliar = true,
                Afp = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01-11-2019"),
                FechaFin = Convert.ToDateTime("30-11-2019")
            };
            ConceptosDePago conceptos = new ConceptosDePago
            {
                MontoHorasExtra = 50,
                MontoReintegros = 50,
                OtrosIngresos = 100
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptos
            };

            decimal resEsperado, resObtenido;
            resEsperado = 3293;
            resObtenido = boleta.CalcularTotalDeIngresos();
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Test1_CalcularTotalDeDescuentos()
        {

            Afp afp = new Afp
            {
                PorcentajeDescuento = 15
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 25,
                HorasSemanales = 30,
                AsignacionFamiliar = true,
                Afp = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01-11-2019"),
                FechaFin = Convert.ToDateTime("30-11-2019")
            };
            ConceptosDePago conceptos = new ConceptosDePago
            {
                MontoHorasAusente = 0,
                OtrosDescuentos = 0,
                TotalAdelantos = 50
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptos
            };
            decimal resEsperado, resObtenido;
            resEsperado = 500;
            resObtenido = boleta.CalcularTotalDeDescuentos();
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Test1_CalcularSueldoNeto()
        {
            Afp afp = new Afp
            {
                PorcentajeDescuento = 15
            };
            Contrato contrato = new Contrato
            {
                ValorHora = 25,
                HorasSemanales = 30,
                AsignacionFamiliar = true,
                Afp = afp
            };
            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01-11-2019"),
                FechaFin = Convert.ToDateTime("30-11-2019")
            };
            ConceptosDePago conceptos = new ConceptosDePago
            {
                MontoHorasExtra = 50,
                MontoReintegros = 50,
                OtrosIngresos = 100,
                MontoHorasAusente = 0,
                OtrosDescuentos = 0,
                TotalAdelantos = 50
            };
            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo,
                ConceptosDePago = conceptos
            };
            decimal resEsperado, resObtenido;
            resEsperado = 2793;
            resObtenido = boleta.CalcularSueldoNeto();
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Test1_CalcularTotalHoras()
        {
            Contrato contrato = new Contrato
            {
                HorasSemanales = 30
            };

            PeriodoPago periodo = new PeriodoPago
            {
                FechaInicio = Convert.ToDateTime("01-11-2019"),
                FechaFin = Convert.ToDateTime("30-11-2019")
            };

            BoletaPago boleta = new BoletaPago
            {
                Contrato = contrato,
                PeriodoPago = periodo
            };

            decimal resEsperado, resObtenido;
            resEsperado = 120;
            resObtenido = boleta.CalcularTotalHoras();
            Assert.AreEqual(resEsperado, resObtenido);
        }
    }
}
