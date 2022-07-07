using DesafioAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Data
{
    public class Db
    {

        //Listar todos
        public static List<Profissional> FindAll()
        {
            
            using (var context = new ProfissionalContext())
            {

                var busca = context.Profissional.ToList();
                busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));
                
                return busca;
            }
        }


        public static List<Profissional> FindByName(string nome)
        {
            
            using (var context = new ProfissionalContext())
            {
                List<Profissional> busca = context.Profissional
                    .Where(c => c.NomeCompleto.Contains(nome)).
                    ToList();


                return busca;
            }
        }

        public static List<Profissional> FindByRegister(string registro)
        {
            string[] range = registro.Split('-');
            int a = Convert.ToInt16(range[0]);
            int b = Convert.ToInt16(range[1]);

            using (var context = new ProfissionalContext())
            {
                var busca = context.Profissional
                    .Where(c => c.NumeroRegistro >= a && c.NumeroRegistro <= b)
                    .ToList();

                return busca;
            }
        }

        public static List<Profissional> FindByActive()
        {
            using (var context = new ProfissionalContext())
            {
                List<Profissional> busca = context.Profissional
                    .Where(c => c.Ativo == true)
                    .ToList();

                return busca;
            }
        }

        public static Profissional CreateProfissional(Profissional t1)
        {

            using (var context = new ProfissionalContext())
            {

                var p1 = context.Profissional.Where(b => b.NomeCompleto == t1.NomeCompleto);

                if (p1.Count() == 0)
                {
                    t1.DataCriacao = DateTime.Now;

                    context.Profissional.Add(t1);
                    context.SaveChanges();

                    return t1;
                }
                else
                {
                    return null;
                }
            }
        }


        public static Profissional EditProfissional(int id, Profissional p1)
        {

            using (var context = new ProfissionalContext())
            {

                var busca = context.Profissional
                    .First(c => c.Id == id);

                busca.NomeCompleto = p1.NomeCompleto;
                busca.CPF = p1.CPF;
                busca.DataNascimento = p1.DataNascimento;
                busca.Sexo = p1.Sexo;
                busca.Ativo = p1.Ativo;
                busca.ValorRenda = p1.ValorRenda;
                busca.CEP = p1.CEP;
                busca.Cidade = p1.Cidade;

                context.SaveChanges();

                return busca;
            }
        }


        public static Profissional DeleteProfissional(int id)
        {

            using (var context = new ProfissionalContext())
            {
                Profissional p1 = context.Profissional.First(c => c.Id.Equals(id));

                if (p1 != null)
                {
                    context.Profissional.Remove(p1);
                    context.SaveChanges();
                    return p1;
                }
                else
                {
                    return null;
                }
            }
        }
        
    }
}
