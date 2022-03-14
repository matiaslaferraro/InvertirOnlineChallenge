using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private readonly decimal _lado;
        private string _nombre;
        public Circulo(decimal ancho, string nombre)
        {
            _lado = ancho;
            this._nombre = nombre;
        }
    
        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }
        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }
        public override string GetNombre()
        {
            return this._nombre;
        }
    }
}
