namespace ex01
{
    public class Percurso
    {
        private List<int> trajeto = new List<int>();
        public int Distancia { get; private set; }
        public string Trajeto { get { return String.Join(",", this.trajeto); } }
        public void AdicionaCidade(int cidade) => trajeto.Add(cidade); 
        public void AdicionaDistancia(int distancia) => this.Distancia += distancia;
        public int Tamanho () => this.trajeto.Count;
        public int UltimaCidade () => this.trajeto.Last();

        public override string ToString() => $"Trajeto {this.Trajeto} = {this.Distancia} km";
    }
}