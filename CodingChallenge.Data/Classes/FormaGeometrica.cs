using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public FormaGeometrica() { }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string GetNombre();
        public static string Imprimir(List<FormaGeometrica> formas, ILenguaje lenguaje) 
        {
            var sb = new StringBuilder();
            //Inglés es el lenguaje por defecto según la clase FormaGeometrica de enunciado. 
            if (!formas.Any())
                sb.Append("<h1>" + lenguaje.Traducir("Empty list of shapes!") + "</h1>");
            else
            {
                var formaAgrupada = new FormaAgrupada();
                ArmarHeader(lenguaje,sb);
                var formasAgrupadas = formaAgrupada.GetAgrupamientos(formas);
                ArmarBody(formas, lenguaje,sb, formasAgrupadas);
                ArmarFooter(formasAgrupadas, lenguaje,sb);
            }
            return sb.ToString();
        }
        public static void ArmarHeader(ILenguaje lenguaje, StringBuilder sb)
        {
            sb.Append("<h1>" + lenguaje.Traducir("Shapes report") + "</h1>");
        }
        public static void ArmarBody(List<FormaGeometrica> formas, ILenguaje lenguaje, StringBuilder sb, List<FormaAgrupada> formasAgrupadas)
        {
            foreach (var forma in formasAgrupadas)
            {
                sb.Append(ObtenerLinea(forma, lenguaje));
            }
        }
        public static string ObtenerLinea(FormaAgrupada formaAgrupada, ILenguaje lenguaje)
        {
            if (formaAgrupada.Cantidad > 0)
                return $"{formaAgrupada.Cantidad} {(formaAgrupada.Cantidad > 1 ? lenguaje.Traducir(lenguaje.GetPlural(formaAgrupada.Forma)) : lenguaje.Traducir(formaAgrupada.Forma))} | {lenguaje.Traducir("Area")} {formaAgrupada.SumaAreas:#.##} | {lenguaje.Traducir("Perimeter")} {formaAgrupada.SumaPerimetros:#.##} <br/>";
            else
                return string.Empty;
        }
        public static void ArmarFooter(List<FormaAgrupada> formasAgrupadas,ILenguaje lenguaje, StringBuilder sb)
        {
            var sumatoria = (from formaAgrupada in formasAgrupadas 
                          select new
                            {
                                CantidadTotal = formasAgrupadas.Sum(x=> x.Cantidad),
                                AreaTotal = formasAgrupadas.Sum(x => x.SumaAreas),
                                PerimetroTotal = formasAgrupadas.Sum(x => x.SumaPerimetros)
                            }).FirstOrDefault();
            sb.Append("TOTAL:<br/>");
            sb.Append(sumatoria.CantidadTotal + " " + lenguaje.Traducir("shapes") + " ");
            sb.Append(lenguaje.Traducir("Perimeter") + " " + sumatoria.PerimetroTotal.ToString("#.##") + " ");
            sb.Append(lenguaje.Traducir("Area") + " " + sumatoria.AreaTotal.ToString("#.##"));
        }
        public class FormaAgrupada
        {
            public FormaAgrupada() { }
            public string Forma { get; set; }
            public decimal SumaAreas { get; set; }
            public decimal SumaPerimetros { get; set; }
            public int Cantidad { get; set; }
            public List<FormaAgrupada> GetAgrupamientos(List<FormaGeometrica> formas)
            {
                return (from forma in formas
                        group forma by forma.GetNombre()
                       into formagroup
                        select new FormaAgrupada()
                        {
                            Forma = formagroup.Key.ToString(),
                            SumaAreas = formagroup.Sum(x => x.CalcularArea()),
                            SumaPerimetros = formagroup.Sum(x => x.CalcularPerimetro()),
                            Cantidad = formagroup.Count()
                        }).ToList();
            }
        }
    }
}
