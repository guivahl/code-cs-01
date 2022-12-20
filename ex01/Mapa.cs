namespace ex01
{
    public class Mapa
    {
        public const int OPCAO_AUTOMATICA = 1;
        public const int OPCAO_MANUAL = 2;
        private int qtdCidades = 0;
        private int[,] distancias;

        public Mapa(int qtdCidades) {
            this.qtdCidades = qtdCidades;
            this.distancias = new int[qtdCidades, qtdCidades];
        }
        public bool EhCidadeValida(int cidade) {
            if (cidade < 0 || cidade >= this.qtdCidades) {
                System.Console.WriteLine($"Cidade inválida!");
                return false;
            }

            return true;
        }

        public int ConsultaDistancia(int origem, int destino) {
            bool saoCidadesValidas = this.EhCidadeValida(origem) && this.EhCidadeValida(destino);

            if (!saoCidadesValidas) return 0;

            return this.distancias[origem, destino];
        }

        public bool TentaAdicionarDistancia(int origem, int destino, int distancia){
            bool saoCidadesValidas = this.EhCidadeValida(origem) && this.EhCidadeValida(destino);

            if (!saoCidadesValidas) return false;

            if (origem == destino) return false;

            this.distancias[origem, destino] = distancia;
            this.distancias[destino, origem] = distancia;

            return true;
        }

        private int GeraDistanciaAleatoria() {
            const int DISTANCIA_MAXIMA = 10;
            const int DISTANCIA_MINIMA = 1;

            Random random = new Random();

            return random.Next(DISTANCIA_MINIMA, DISTANCIA_MAXIMA);
        }

        private int LeDistancia(int origem, int destino) {
            System.Console.Write($"Qual distância entre {origem} e {destino} (em km)? ");
            
            int distancia = System.Console.ReadLine().ToInt();

            return distancia;
        }

        public void Preencher() {
            System.Console.Write("Deseja utilizar preenchimento automático (1.Sim  2.Não)? ");
            
            int devePreencherAutom = System.Console.ReadLine().ToInt();

            while (devePreencherAutom != Mapa.OPCAO_AUTOMATICA && devePreencherAutom != Mapa.OPCAO_MANUAL) {
                System.Console.Write("Por favor, preencha uma opção válida. Usar preenchimento automático (1.Sim  2.Não)? ");
                devePreencherAutom = System.Console.ReadLine().ToInt();
            }
        
            for(int linha = 0; linha < this.qtdCidades; linha++) {
                for(int coluna = 0; coluna < this.qtdCidades; coluna++) {
                    int distancia = devePreencherAutom switch
                    {
                        Mapa.OPCAO_AUTOMATICA => GeraDistanciaAleatoria(),
                        Mapa.OPCAO_MANUAL => LeDistancia(linha, coluna),
                        _ => LeDistancia(linha, coluna)
                    };

                    this.TentaAdicionarDistancia(linha, coluna, distancia);
                }
            }
        }

        public override string ToString() {
            string resultado = "";
            string cabecalho = $"i\\j ", corpoTabela = "";

            for(int indiceCabeçalho = 0; indiceCabeçalho < this.qtdCidades; indiceCabeçalho++) {
                cabecalho = string.Concat(cabecalho, indiceCabeçalho, " ");
            }
            cabecalho = string.Concat(cabecalho, Environment.NewLine);


            for(int linha = 0; linha < this.qtdCidades; linha++) {
                corpoTabela = string.Concat(corpoTabela, linha, "   ");
                
                for(int coluna = 0; coluna < this.qtdCidades; coluna++) {
                    int valorTabela = this.distancias[linha, coluna];

                    corpoTabela = string.Concat(corpoTabela, valorTabela, " ");
                }

                corpoTabela = string.Concat(corpoTabela, Environment.NewLine);
            }

            resultado = String.Concat(Environment.NewLine, cabecalho, corpoTabela, Environment.NewLine);

            return resultado;
        }
    }
}