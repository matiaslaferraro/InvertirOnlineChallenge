using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Triangulo: FormaGeometrica
    {
        private decimal _base;
        private decimal _lado2;
        private decimal _lado3;
        private string _tipo;
        private decimal _altura;
        private String[] _tipos = new String[3] { "Equilateral", "Scalene", "Isosceles" };
        private ILenguaje _lenguaje;
        public string GetTipo() { return this._tipo; }

        public Triangulo(decimal lado1, decimal lado2, decimal lado3, string nombre, ILenguaje lenguaje, decimal altura = 0)
        {
            this._base = lado1;
            this._lado2 = lado2;
            this._lado3 = lado3;
            this._tipo = nombre;
            this._altura = altura;
            this._lenguaje = lenguaje;

            if (this._tipo.Equals(lenguaje.Traducir(_tipos[0])) && !EsTrianguloEquilatero())
                throw new Exception(lenguaje.Traducir("It is not an equilateral triangle."));
        }
        public override decimal CalcularArea()
        {
            if (this._altura > 0)
                return (this._base * this._altura)/2;
            else { 
                var semiperimetro = (double)CalcularSemiPerimetro();
                return (decimal)Math.Sqrt(semiperimetro * (semiperimetro - (double)_base) * (semiperimetro - (double)_lado2) * (semiperimetro- (double)_lado3));
            }
        }
        public override decimal CalcularPerimetro()
        {
            return _base + _lado2 + _lado3;
        }
        public decimal CalcularSemiPerimetro()
        {
            return CalcularPerimetro() / 2;
        }
        public bool EsTrianguloEquilatero()
        {
            return _base == _lado2 && _lado2 == _lado3; 
        }
        public override string GetNombre()
        {
            return _tipo;
        }
    }
}
