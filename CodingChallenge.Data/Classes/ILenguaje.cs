using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public interface ILenguaje
    {
        string Traducir(string texto);
        void AgregarNuevaTraduccion(string texto, string traduccion);
        void AgregarNuevoPlural(string singular, string plural);
        string GetPlural(string texto);
    }
}
