using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;

namespace ModelPruebas
{
    [TestClass]
    public class ContratoTest
    {

        //R01
        [TestMethod]
        public void Test1_ValidarVigenciaContrato()
        {

            Contrato contrato = new Contrato
            {
                Estado = 1,
                FechaFin = Convert.ToDateTime("15-09-19")
            };

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarVigenciaContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarVigenciaContrato()
        {

            Contrato contrato = new Contrato
            {
                Estado = 1,
                FechaFin = DateTime.Today
            };

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarVigenciaContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarVigenciaContrato()
        {

            Contrato contrato = new Contrato
            {
                Estado = 1,
                FechaFin = Convert.ToDateTime("20-10-20")
            };

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarVigenciaContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test4_ValidarVigenciaContrato()
        {

            Contrato contrato = new Contrato
            {
                FechaFin = Convert.ToDateTime("20-10-19"),
                Estado = 0
            };

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarVigenciaContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }



        //R03
        [TestMethod]
        public void Test1_ValidarFechaFinNuevoContrato()
        {
            Contrato contrato = new Contrato();

            contrato.FechaInicio = Convert.ToDateTime("20-06-19");
            contrato.FechaFin = Convert.ToDateTime("20-10-19");

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarFechaFinNuevoContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }


        [TestMethod]
        public void Test2_ValidarFechaFinNuevoContrato()
        {
            Contrato contrato = new Contrato();

            contrato.FechaInicio = Convert.ToDateTime("20-09-19");
            contrato.FechaFin = Convert.ToDateTime("20-10-19");

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarFechaFinNuevoContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarFechaFinNuevoContrato()
        {
            Contrato contrato = new Contrato();

            contrato.FechaInicio = Convert.ToDateTime("15-06-15");
            contrato.FechaFin = Convert.ToDateTime("20-10-19");

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarFechaFinNuevoContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test4_ValidarFechaFinNuevoContrato()
        {
            Contrato contrato = new Contrato();

            contrato.FechaInicio = Convert.ToDateTime("20-06-19");
            contrato.FechaFin = Convert.ToDateTime("20-05-19");

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarFechaFinNuevoContrato();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        //R02

        [TestMethod]
        public void Test1_ValidarFechaInicioNuevoContrato()
        {
            Contrato contrato = new Contrato
            {
                FechaInicio = Convert.ToDateTime("20-10-19")
            };
            DateTime fechaFinAntigua = Convert.ToDateTime("15-10-15");

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarFechaInicioNuevoContrato(fechaFinAntigua);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarFechaInicioNuevoContrato()
        {
            Contrato contrato = new Contrato
            {
                FechaInicio = Convert.ToDateTime("15-10-15")
            };
            DateTime fechaFinAntigua = Convert.ToDateTime("20-10-19");
            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarFechaInicioNuevoContrato(fechaFinAntigua);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }


        //R04
        [TestMethod]
        public void Test1_ValidarHorasContratadas()
        {
            Contrato contrato = new Contrato();
            contrato.HorasSemanales = 20;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarHorasContratadas();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarHorasContratadas()
        {
            Contrato contrato = new Contrato();
            contrato.HorasSemanales = 5;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarHorasContratadas();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarHorasContratadas()
        {
            Contrato contrato = new Contrato();
            contrato.HorasSemanales = 50;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarHorasContratadas();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        //R05

        [TestMethod]
        public void Test1_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "primaria";
            contrato.ValorHora = 6;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test2_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "primaria";
            contrato.ValorHora = 3;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test3_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "primaria";
            contrato.ValorHora = 66;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test4_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "secundaria";
            contrato.ValorHora = 6;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test5_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "primarias";
            contrato.ValorHora = 6;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }
        //bachiller
        [TestMethod]
        public void Test6_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "bachiller";
            contrato.ValorHora = 16;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test7_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "bachiller";
            contrato.ValorHora = 6;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test8_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "bachiller";
            contrato.ValorHora = 60;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }
        //Profesional

        [TestMethod]
        public void Test9_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "profesional";
            contrato.ValorHora = 25;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test10_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "profesional";
            contrato.ValorHora = 6;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test11_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "profesional";
            contrato.ValorHora = 600;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }
        //MAgister
        [TestMethod]
        public void Test12_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "magister";
            contrato.ValorHora = 36;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test13_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "magister";
            contrato.ValorHora = 6;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test14_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "magister";
            contrato.ValorHora = 60;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }
        //Doctor

        [TestMethod]
        public void Test15_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "doctor";
            contrato.ValorHora = 56;

            bool res_Esperado = true;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test16_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "doctor";
            contrato.ValorHora = 6;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test17_ValidarValorHora()
        {
            Contrato contrato = new Contrato();
            string gradoAcademico = "doctor";
            contrato.ValorHora = 61;

            bool res_Esperado = false;
            bool res_Obtenido = contrato.ValidarValorHora(gradoAcademico);
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        //R03 pagos
        [TestMethod]
        public void Test1_CalcularAsignacionFamiliar()
        {
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = true
            };

            decimal res_Esperado = 93;
            decimal res_Obtenido = contrato.CalcularAsignacionFamiliar();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }

        [TestMethod]
        public void Test2_CalcularAsignacionFamiliar()
        {
            Contrato contrato = new Contrato
            {
                AsignacionFamiliar = false
            };

            decimal res_Esperado = 0;
            decimal res_Obtenido = contrato.CalcularAsignacionFamiliar();
            Assert.AreEqual(res_Esperado, res_Obtenido);
        }


    }
}
