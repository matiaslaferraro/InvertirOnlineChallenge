using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        //Idioma Inglés por defecto como dice el enunciado en la clase original de FormaGeometrica.cs
        [TestCase]
        public void TestEsTrianguloEquilatero()
        {
            Triangulo triangulo = new Triangulo(4, 4, 4,"Equilateral", new Castellano());
            Assert.IsTrue(triangulo.EsTrianguloEquilatero());

        }

        [TestCase]
        public void TestNoEsTrianguloEquilatero()
        {
            try
            {
                Triangulo triangulo = new Triangulo(4, 4, 5, "Equilateral", new Castellano());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No es un triángulo equilatrero.", ex.Message);
            }
        }

        [TestCase]
        public void TestSemiPerimetroTrianguloEquilatero()
        {
            Triangulo triangulo = new Triangulo(4,4,4, "Equilateral", new Castellano());
            decimal semiPerimetro = triangulo.CalcularSemiPerimetro();
            Assert.AreEqual(6, semiPerimetro);
        }

        [TestCase]
        public void TestPerimetroTrianguloEquilatero()
        {
            FormaGeometrica triangulo = new Triangulo(4, 4, 4, "Equilateral", new Castellano());
            decimal perimetro = triangulo.CalcularPerimetro();
            Assert.AreEqual(12, perimetro);
        }

        [TestCase]
        public void TestAreaTrianguloEquilateroSinAltura()
        {
            FormaGeometrica triangulo = new Triangulo(4,4,4, "Equilateral", new Castellano());
            decimal area = triangulo.CalcularArea();
            Assert.AreEqual(6.93, Math.Round(area, 2));
        }

        [TestCase]
        public void TestAreaTrianguloEquilateroConAltura()
        {
            FormaGeometrica triangulo = new Triangulo(4, 4, 4, "Equilateral", new Castellano(),3.465m);
            decimal area = triangulo.CalcularArea();
            Assert.AreEqual(6.93, Math.Round(area, 2));
        }

        [TestCase]
        public void TestAreaCirculo()
        {
            FormaGeometrica circulo = new Circulo(3, "Circle");
            decimal area = circulo.CalcularArea();
            Assert.AreEqual(7.07, Math.Round(area, 2));
        }
        [TestCase]
        public void TestPerimetroCirculo()
        {
            FormaGeometrica circulo = new Circulo(3, "Circle");
            decimal perimetro = circulo.CalcularPerimetro();
            Assert.AreEqual(9.42m, Math.Round(perimetro, 2));
        }

        [TestCase]
        public void TestAreaTrapecioSinAltura()
        {
            FormaGeometrica trapecio = new Trapecio(7, 4, 4.12m, 4.47m, "Trapezoid");
            decimal area = trapecio.CalcularArea();
            Assert.AreEqual(21.98m, Math.Round(area, 2)); // Si se redondea es 22m.
        }
        
        [TestCase]
        public void TestAreaTrapecioConAltura()
        {
            FormaGeometrica trapecio = new Trapecio(7, 4, 4.12m, 4.47m, "Trapezoid", 4);
            decimal area = trapecio.CalcularArea();
            Assert.AreEqual(22m, Math.Round(area, 2));
        }

        [TestCase]
        public void TestPerimetroTrapecio()
        {
            FormaGeometrica trapecio = new Trapecio(7, 3, 4.12m, 5, "Trapezoid");
            decimal perimetro = trapecio.CalcularPerimetro();
            Assert.AreEqual(19.12m, Math.Round(perimetro, 2));
        }

        [TestCase]
        public void TestTraducirCirculoAlEspañol()
        {
            ILenguaje lenguaje = new Castellano();
            Assert.AreEqual("Circulo", lenguaje.Traducir("Circle"));
        }
        [TestCase]
        public void TestValidarListaVaciaVaciaAlEspañol()
        {
            ILenguaje lenguaje = new Castellano();
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", FormaGeometrica.Imprimir(new List<FormaGeometrica>(), lenguaje));
        }

        [TestCase]
        public void TestObtenerLinea()
        {
            ILenguaje lenguaje = new Castellano();
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            FormaGeometrica.FormaAgrupada formaAgrupada = new FormaGeometrica.FormaAgrupada();
            formas.Add(new Circulo(3, "Circle"));
            formas.Add(new Circulo(5, "Circle"));
            formas.Add(new Cuadrado(4,"Square"));
            var x = formaAgrupada.GetAgrupamientos(formas);
            List<FormaGeometrica.FormaAgrupada> formaAgrupadaEsperada = new List<FormaGeometrica.FormaAgrupada>();
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Circle",
                SumaAreas = 26.7035375555132150M,
                SumaPerimetros = 25.13274122871832M,
                Cantidad = 2
            });
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Square",
                SumaAreas = 16,
                SumaPerimetros = 16,
                Cantidad = 1
            });
            Assert.AreEqual("2 Circulos | Area 26,7 | Perimetro 25,13 <br/>", FormaGeometrica.ObtenerLinea(x[0], lenguaje));
        }

        [TestCase]
        public void TestResumenListaVaciaEnFormasEspañol()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(),new Castellano()));
        }
        [TestCase]
        public void TestResumenListaVaciaFormasPorgues()
        {
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), new Portugues()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(),new Ingles()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            formas.Add(new Cuadrado(5, "Square"));
            
            var resumen = FormaGeometrica.Imprimir(formas, new Castellano());
            
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadradosEnIngles()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            formas.Add(new Cuadrado(5, "Square"));
            formas.Add(new Cuadrado(1, "Square"));
            formas.Add(new Cuadrado(3, "Square"));
            
            var resumen = FormaGeometrica.Imprimir(formas, new Ingles());

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }


        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            ILenguaje lenguaje = new Castellano();
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            FormaGeometrica.FormaAgrupada formaAgrupada = new FormaGeometrica.FormaAgrupada();
            formas.Add(new Circulo(3, "Circle"));
            formas.Add(new Circulo(5, "Circle"));
            formas.Add(new Cuadrado(4, "Square"));
            var x = formaAgrupada.GetAgrupamientos(formas);
            List<FormaGeometrica.FormaAgrupada> formaAgrupadaEsperada = new List<FormaGeometrica.FormaAgrupada>();
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Circle",
                SumaAreas = 26.7035375555132150M,
                SumaPerimetros = 25.13274122871832M,
                Cantidad = 2
            });
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Square",
                SumaAreas = 16,
                SumaPerimetros = 16,
                Cantidad = 1
            });
            Assert.AreEqual(
               "<h1>Reporte de Formas</h1>2 Circulos | Area 26,7 | Perimetro 25,13 <br/>1 Cuadrado | Area 16 | Perimetro 16 <br/>TOTAL:<br/>3 formas Perimetro 41,13 Area 42,7",
               FormaGeometrica.Imprimir(formas,lenguaje));
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            ILenguaje lenguaje = new Ingles();
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            FormaGeometrica.FormaAgrupada formaAgrupada = new FormaGeometrica.FormaAgrupada();
            formas.Add(new Circulo(3, "Circle"));
            formas.Add(new Circulo(5, "Circle"));
            formas.Add(new Cuadrado(4, "Square"));
            var x = formaAgrupada.GetAgrupamientos(formas);
            List<FormaGeometrica.FormaAgrupada> formaAgrupadaEsperada = new List<FormaGeometrica.FormaAgrupada>();
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Circle",
                SumaAreas = 26.7035375555132150M,
                SumaPerimetros = 25.13274122871832M,
                Cantidad = 2
            });
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Square",
                SumaAreas = 16,
                SumaPerimetros = 16,
                Cantidad = 1
            });

            var resumen = FormaGeometrica.Imprimir(formas, lenguaje);

            Assert.AreEqual(
               "<h1>Shapes report</h1>2 Circles | Area 26,7 | Perimeter 25,13 <br/>1 Square | Area 16 | Perimeter 16 <br/>TOTAL:<br/>3 shapes Perimeter 41,13 Area 42,7",
               resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnPortugues()
        {
            ILenguaje lenguaje = new Portugues();
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            FormaGeometrica.FormaAgrupada formaAgrupada = new FormaGeometrica.FormaAgrupada();
            formas.Add(new Circulo(3, "Circle"));
            formas.Add(new Circulo(5, "Circle"));
            formas.Add(new Cuadrado(4, "Square"));
            var x = formaAgrupada.GetAgrupamientos(formas);
            List<FormaGeometrica.FormaAgrupada> formaAgrupadaEsperada = new List<FormaGeometrica.FormaAgrupada>();
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Circle",
                SumaAreas = 26.7035375555132150M,
                SumaPerimetros = 25.13274122871832M,
                Cantidad = 2
            });
            formaAgrupadaEsperada.Add(new FormaGeometrica.FormaAgrupada()
            {
                Forma = "Square",
                SumaAreas = 16,
                SumaPerimetros = 16,
                Cantidad = 1
            });

            var resumen = FormaGeometrica.Imprimir(formas, lenguaje);

            Assert.AreEqual(
               "<h1>Relatório de formulários</h1>2 Circulos | Area 26,7 | Perimetro 25,13 <br/>1 Quadrado | Area 16 | Perimetro 16 <br/>TOTAL:<br/>3 formas Perimetro 41,13 Area 42,7",
               resumen);
        }

    }
}
