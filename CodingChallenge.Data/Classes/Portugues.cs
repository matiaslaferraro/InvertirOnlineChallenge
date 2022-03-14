using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Portugues: ILenguaje
    {
        private Dictionary<string, string> _diccionario;
        private Dictionary<string, string> _plurales;
        public Portugues()
        {
            _diccionario = new Dictionary<string, string>();
            _plurales = new Dictionary<string, string>();
            AgregarNuevoPlural("Circle", "Circles");
            AgregarNuevoPlural("Square", "Squares");
            AgregarNuevoPlural("Triangle", "Triangles");
            AgregarNuevoPlural("Trapezoid", "Trapezoids");
            AgregarNuevaTraduccion("Empty list of shapes!", "Lista vazia de formas!");
            AgregarNuevaTraduccion("Shapes report", "Relatório de formulários");
            AgregarNuevaTraduccion("Square", "Quadrado");
            AgregarNuevaTraduccion("Squares", "Quadrados");
            AgregarNuevaTraduccion("Circle", "Circulo");
            AgregarNuevaTraduccion("Circles", "Circulos");
            AgregarNuevaTraduccion("Area", "Area");
            AgregarNuevaTraduccion("Perimeter", "Perimetro");
            AgregarNuevaTraduccion("shapes", "formas");
            AgregarNuevaTraduccion("Triangle", "Triângulo");
            AgregarNuevaTraduccion("Trapezoid", "Trapézio");
            AgregarNuevaTraduccion("Trapezoids", "Trapézios");
            AgregarNuevaTraduccion("Equilateral", "Equilatero");
            AgregarNuevaTraduccion("It is not an equilateral triangle.", "Não é um triângulo equilátero.");
        }

        public string Traducir(string texto)
        {
            if (_diccionario.ContainsKey(texto))
                return _diccionario[texto].ToString();
            else
                throw new Exception("Não há tradução.");
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
                throw new Exception("Não há plural.");
        }
        public void AgregarNuevoPlural(string singular, string plural)
        {
            _plurales.Add(singular, plural);
        }
    }
}
