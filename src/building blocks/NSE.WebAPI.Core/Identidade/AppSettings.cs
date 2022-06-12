using System.Collections.Generic;

namespace NSE.WebAPI.Core.Identidade
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public IEnumerable<Contexto> Contextos { get; set; }

    }

    public class Contexto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}
