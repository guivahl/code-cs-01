namespace ex01;

class Program
{
    static void Main(string[] args)
    {
        DesktopTxt matriz = new DesktopTxt("matriz.txt");
        
        if (!matriz.ExisteArquivo()) return;
        
        DesktopTxt caminho = new DesktopTxt("caminho.txt");
        
        if (!caminho.ExisteArquivo()) return;
        
        int[] valoresMapa = matriz.ObterValores().ToInt();

        Mapa mapa = new Mapa(matriz.QuantidadeLinhas());
        mapa.Preencher(valoresMapa);

        System.Console.Write(mapa.ToString());

        int[] valoresCaminho = caminho.ObterValores().ToInt();
        Percurso percurso = new Percurso();

        percurso.Preencher(mapa, valoresCaminho);

        System.Console.Write(mapa.ToString());
        System.Console.WriteLine(percurso.ToString());
    }
}
