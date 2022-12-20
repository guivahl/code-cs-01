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

        System.Console.Write("Qual cidade você está? ");
        
        int proximaCidade = System.Console.ReadLine().ToInt();

        while (mapa.EhCidadeValida(proximaCidade))  {
            if (percurso.Tamanho() > 0) {
                int cidadeOrigem = percurso.UltimaCidade();
                int distancia = mapa.ConsultaDistancia(cidadeOrigem, proximaCidade);
                
                percurso.AdicionaDistancia(distancia);
            }

            percurso.AdicionaCidade(proximaCidade);

            System.Console.WriteLine($"Percurso atualizado: {percurso.Trajeto}");            
            System.Console.Write("Qual próxima cidade (para Parar, digite -1)? ");
           
            proximaCidade = System.Console.ReadLine().ToInt();
        }

        System.Console.Write(mapa.ToString());
        System.Console.WriteLine($"Trajeto (cidades): {percurso.Trajeto}");
        System.Console.WriteLine($"Percurso (em km): {percurso.Distancia}");
        
        System.Console.WriteLine(percurso.ToString());
    }
}
