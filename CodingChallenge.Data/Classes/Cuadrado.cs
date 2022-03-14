using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;
        private string _nombre;
        public Cuadrado(decimal lado, string nombre)
        {
            _lado = lado;
            _nombre = nombre;
        }
        public override decimal CalcularArea()
        {
            return _lado* _lado;
        }
        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
        public override string GetNombre()
        {
            return _nombre;
        }
    }
}
