namespace ex01;

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class Program
{
    static void Main(string[] args)
    {
        DesktopCsv csvMatriz = new DesktopCsv("matriz.txt");

        if (!csvMatriz.ExisteArquivo()) return;
                
        DesktopCsv csvCaminho = new DesktopCsv("caminho.txt");
        
        if (!csvCaminho.ExisteArquivo()) return;

        List<string> valoresMatriz = csvMatriz.LeDados();
        List<string> valoresCaminho = csvCaminho.LeDados();
        
        int numeroCidades = Convert.ToInt32(Math.Sqrt(valoresMatriz.Count));

        Mapa mapa = new Mapa(numeroCidades);
        Percurso percurso = new Percurso();

        mapa.Preencher(valoresMatriz.ToArray().ToInt());
        percurso.Preencher(mapa, valoresCaminho.ToArray().ToInt());

        System.Console.Write(mapa.ToString());
        System.Console.WriteLine(percurso.ToString());
    }
}
