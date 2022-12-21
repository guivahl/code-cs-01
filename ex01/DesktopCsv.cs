using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace ex01
{
    public class DesktopCsv {
        private string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string caminhoArquivo;
        private CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
        public DesktopCsv(string nomeArquivo)
        {
            string caminhoArquivo = Path.Join(caminhoDesktop, nomeArquivo);

            this.caminhoArquivo = caminhoArquivo;
        }

        public bool ExisteArquivo() => new FileInfo(caminhoArquivo).Exists;

        public List<string> LeDados() {
            using StreamReader stream = new StreamReader(this.caminhoArquivo);
            using CsvParser csv = new CsvParser(stream, this.csvConfig);
            
            List<string> valoresCsv = new List<string>();

            if (!csv.Read()) return new List<string>();
            
            if (csv.Record == null) return new List<string>();

            foreach (string valor in csv.Record) 
                valoresCsv.Add(valor);

            while (csv.Read()) {
                if (csv.Record == null) continue;
            
                foreach (string valor in csv.Record) 
                    valoresCsv.Add(valor);
            }

            return valoresCsv;
        }
    }

}