namespace ex01;

class Program
{
    static void Main(string[] args)
    {
        System.Console.Write("Quantas cidades deseja adicionar no mapa? ");

        int qtdCidades = System.Console.ReadLine().ToInt();

        Mapa mapa = new Mapa(qtdCidades);

        mapa.Preencher();

        System.Console.Write(mapa.ToString());

        Percurso percurso = new Percurso();

        percurso.Preencher(mapa);

        System.Console.Write(mapa.ToString());
        System.Console.WriteLine($"Trajeto (cidades): {percurso.Trajeto}");
        System.Console.WriteLine($"Percurso (em km): {percurso.Distancia}");
        
        System.Console.WriteLine(percurso.ToString());
    }
}
