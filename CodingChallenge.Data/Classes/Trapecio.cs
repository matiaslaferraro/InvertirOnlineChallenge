using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio: FormaGeometrica
    {
        private readonly decimal _baseMenor;
        private readonly decimal _baseMayor;
        private readonly decimal _ladoDerecho;
        private readonly decimal _ladoIzquierdo;
        private readonly decimal _altura;
        private string _nombre;
        public Trapecio(decimal baseMenor, decimal baseMayor, decimal ladoDerecho, decimal ladoIzquierdo, string nombre, decimal altura = 0)
        {
            _baseMenor = baseMenor;
            _baseMayor = baseMayor;
            _ladoDerecho = ladoDerecho;
            _ladoIzquierdo = ladoIzquierdo;
            _altura = altura;
            _nombre = nombre;
        }
        public Trapecio(decimal baseMenor, decimal baseMayor, decimal altura)
        {
            _baseMenor = baseMenor;
            _baseMayor = baseMayor;
  
        }
        public override decimal CalcularArea() 
        {
            //Conociendo todos sus lados o su altura
            if (_altura > 0)
                return _altura * ((_baseMenor + _baseMayor) / 2);
            else return ((_baseMenor + _baseMayor) / 2) * (decimal)Math.Sqrt(Math.Pow((double)_ladoIzquierdo, 2) - Math.Pow((double)(Math.Pow((double)_ladoIzquierdo, 2) - Math.Pow((double)_ladoDerecho, 2) + Math.Pow((double)_baseMayor - (double)_baseMenor, 2)) / (2 * ((double)_baseMayor - (double)_baseMenor)), 2));
        }
        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _ladoDerecho + _ladoIzquierdo;
        }
        public override string GetNombre()
        {
            return _nombre;
        }
    }
}
