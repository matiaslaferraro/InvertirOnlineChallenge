using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Castellano: ILenguaje
    {
        private Dictionary<string, string> _diccionario;
        private Dictionary<string, string> _plurales;
        public Castellano() 
        {
            _diccionario = new Dictionary<string, string>();
            _plurales = new Dictionary<string, string>();
            AgregarNuevoPlural("Circle", "Circles");
            AgregarNuevoPlural("Square", "Squares");
            AgregarNuevoPlural("Triangle", "Triangles");
            AgregarNuevoPlural("Trapezoid", "Trapezoids");
            AgregarNuevaTraduccion("Empty list of shapes!", "Lista vacía de formas!");
            AgregarNuevaTraduccion("Shapes report", "Reporte de Formas");
            AgregarNuevaTraduccion("Square", "Cuadrado");
            AgregarNuevaTraduccion("Squares", "Cuadrados");
            AgregarNuevaTraduccion("Circle", "Circulo");
            AgregarNuevaTraduccion("Circles", "Circulos");
            AgregarNuevaTraduccion("Area", "Area");
            AgregarNuevaTraduccion("Perimeter", "Perimetro");
            AgregarNuevaTraduccion("shapes", "formas");
            AgregarNuevaTraduccion("Triangle", "Triángulo");
            AgregarNuevaTraduccion("Trapezoid", "Trapecio");
            AgregarNuevaTraduccion("Trapezoids", "Trapecios");
            AgregarNuevaTraduccion("Equilateral", "Equilatero");
            AgregarNuevaTraduccion("It is not an equilateral triangle.", "No es un triángulo equilatrero.");
        }

        public string Traducir(string texto)
        {
            if (_diccionario.ContainsKey(texto))
                return _diccionario[texto].ToString();
            else
                throw new Exception("No existe la traducción.");
        }

        public void AgregarNuevaTraduccion(string texto, string traduccion)
        {
            _diccionario.Add(texto, traduccion);
        }
        public string GetPlural(string texto)
        {
            if (_diccionario.ContainsKey(texto) && _plurales.ContainsKey(texto))
                return _plurales[texto].ToString();
            else
                throw new Exception("No existe el plural.");
        }
        public void AgregarNuevoPlural(string singular, string plural)
        {
            _plurales.Add(singular, plural);
        }
    }
}
