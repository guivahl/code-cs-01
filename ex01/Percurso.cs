namespace ex01
{
    public class Percurso
    {
        private List<int> trajeto = new List<int>();
        public int Distancia { get; private set; }
        public string Trajeto { get { return String.Join(",", this.trajeto.Select(d => d + 1)); } }
        private void AdicionaCidade(int cidade) => trajeto.Add(cidade); 
        private void AdicionaDistancia(int distancia) => this.Distancia += distancia;
        private int Tamanho () => this.trajeto.Count;
        public int UltimaCidade () => this.trajeto.Last();

        public void Preencher(Mapa mapa) {
            System.Console.Write("Qual cidade você está? ");
            
            int proximaCidade = System.Console.ReadLine().ToInt() - 1;

            while (mapa.EhCidadeValida(proximaCidade))  {
                if (this.Tamanho() > 0) {
                    int cidadeOrigem = this.UltimaCidade();
                    int distancia = mapa.ConsultaDistancia(cidadeOrigem, proximaCidade);
                    
                    this.AdicionaDistancia(distancia);
                }

                this.AdicionaCidade(proximaCidade);

                System.Console.WriteLine($"Percurso atualizado: {this.Trajeto}");            
                System.Console.Write("Qual próxima cidade? (para Parar, digite um valor inválido.) ");
            
                proximaCidade = System.Console.ReadLine().ToInt() - 1;
            }
        }

        public override string ToString() => $"Trajeto {this.Trajeto} = {this.Distancia} km";
    }
}