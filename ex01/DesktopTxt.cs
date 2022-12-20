namespace ex01
{
    public class DesktopTxt
    {
        private string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string caminhoArquivo;

        public DesktopTxt(string nomeArquivo)
        {
            string caminhoArquivo = Path.Join(caminhoDesktop, nomeArquivo);

            this.caminhoArquivo = caminhoArquivo;
        }

        public bool ExisteArquivo() => new FileInfo(caminhoArquivo).Exists;

        public string LerTexto() => File.ReadAllText(this.caminhoArquivo);

        public int QuantidadeLinhas() => File.ReadLines(this.caminhoArquivo).Count();

        public string[] ObterValores() =>
            this.LerTexto()
                    .Replace(Environment.NewLine, ",")
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Where(valor => Int32.TryParse(valor, out int x))
                    .ToArray();
    }
}