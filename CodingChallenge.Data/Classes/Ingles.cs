using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Ingles: ILenguaje
    {
        private Dictionary<string, string> _diccionario;
        private Dictionary<string, string> _plurales;
        public Ingles()
        {
            _diccionario = new Dictionary<string, string>();
            _plurales = new Dictionary<string, string>();
            AgregarNuevoPlural("Circle", "Circles");
            AgregarNuevoPlural("Square", "Squares");
            AgregarNuevoPlural("Triangle", "Triangles");
            AgregarNuevoPlural("Trapezoid", "Trapezoids");
            AgregarNuevaTraduccion("Empty list of shapes!", "Empty list of shapes!");
            AgregarNuevaTraduccion("Shapes report", "Shapes report");
            AgregarNuevaTraduccion("Square", "Square");
            AgregarNuevaTraduccion("Squares", "Squares");
            AgregarNuevaTraduccion("Circle", "Circle");
            AgregarNuevaTraduccion("Circles", "Circles");
            AgregarNuevaTraduccion("Area", "Area");
            AgregarNuevaTraduccion("Perimeter", "Perimeter");
            AgregarNuevaTraduccion("shapes", "shapes");
            AgregarNuevaTraduccion("Triangle", "Triangle");
            AgregarNuevaTraduccion("Trapezoid", "Trapezoid");
            AgregarNuevaTraduccion("Trapezoids", "Trapezoids");
            AgregarNuevaTraduccion("Equilateral", "Equilateral");
        }

        public string Traducir(string texto)
        {
            if (_diccionario.ContainsKey(texto))
                return _diccionario[texto].ToString();
            else
                throw new Exception("There is no traslate.");
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
                throw new Exception("There is no plural.");
        }
        public void AgregarNuevoPlural(string singular, string plural)
        {
            _plurales.Add(singular, plural);
        }
    }
}
