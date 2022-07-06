namespace DesafioAPI.Model
{
    public class ProfissionalSaida
    {

        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public int NumeroRegistro { get; set; }
        public DateTime DataCriacao { get; set; }

        public ProfissionalSaida() { }

        public static List<ProfissionalSaida> ConverteSaida(List<Profissional> lista)
        {
            List<ProfissionalSaida> listaSaida = new List<ProfissionalSaida>();
            foreach(Profissional p1 in lista)
            {
                ProfissionalSaida p2 = new ProfissionalSaida();
                p2.NomeCompleto = p1.NomeCompleto;
                p2.NumeroRegistro = p1.NumeroRegistro;
                p2.CPF = p1.CPF;
                p2.Ativo = p1.Ativo;
                p2.DataCriacao = p1.DataCriacao;

                listaSaida.Add(p2);
            }
            return listaSaida;
        }

    }
}
