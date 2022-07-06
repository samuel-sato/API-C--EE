using DesafioAPI.Model;
using DesafioAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfissionalController : ControllerBase
    {

        //Lista todos
        [HttpGet("/profissional/busca/todos")]
        public List<ProfissionalSaida> GetAll()
        {
            Console.WriteLine("Escreve profissional");
            using (var context = new ProfissionalContext())
            {

                var busca = context.Profissional.ToList();
                busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));
                foreach (Profissional p in busca)
                {
                    Console.WriteLine($"{p}");
                }
                return ProfissionalSaida.ConverteSaida(busca);
            }
        }

        //Busca por nome
        [HttpGet("/profissional/busca/nome/{nome}")]
        public List<ProfissionalSaida> GetByName(string nome)
        {
            Console.WriteLine("Escreve profissional");
            using (var context = new ProfissionalContext())
            {
                List<Profissional> busca = context.Profissional
                    .Where(c => c.NomeCompleto.Contains(nome)).
                    ToList();

                busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));

                return ProfissionalSaida.ConverteSaida(busca);
            } 
        }

        //Busca por registro (range)
        [HttpGet("/profissional/busca/registro/{registro}")]
        public List<ProfissionalSaida> GetByRegister(string registro)
        {
            string[] range = registro.Split('-');
            int a = Convert.ToInt16(range[0]);
            int b = Convert.ToInt16(range[1]);
            
            using (var context = new ProfissionalContext())
            {
                var busca = context.Profissional
                    .Where(c => c.NumeroRegistro >= a && c.NumeroRegistro <= b)
                    .ToList();

                busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));

                return ProfissionalSaida.ConverteSaida(busca);
            }
        }

        //Busca por ativos
        [HttpGet("/profissional/busca/ativo")]
        public List<ProfissionalSaida> GetByActivate()
        {
            using (var context = new ProfissionalContext())
            {
                List<Profissional> busca = context.Profissional
                    .Where(c => c.Ativo == true)
                    .ToList();

                busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));

                return ProfissionalSaida.ConverteSaida(busca);
            }
        }

        //Editar
        [HttpPut("/profissional/{id}")]
        public IActionResult Edit(int id, Profissional p1)
        {
            Console.WriteLine($"ID {id}");

            if (!Ferramenta.ValidaCPF(p1.CPF))
            {
                return BadRequest(new
                {
                    Mensage = "CPF invalido",
                    Erro = true
                });
            }

            if (!Ferramenta.ValidaIdade(p1.DataNascimento))
            {
                return BadRequest(new
                {
                    Mensage = "Idade Insuficiente",
                    Erro = true
                });
            }
            
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

                return Ok();
            }
            
            Console.WriteLine($"PESSOA Editada com sucesso {p1}");
            return Ok();

        }
        //POST-PROFISSIONAL
        //FALTA autoincrement numeroRegistro;
        [HttpPost("/profissional")]
        public IActionResult PostProfissional(Profissional t1)
        {
            if (!Ferramenta.ValidaCPF(t1.CPF))
            {
                return BadRequest(new
                {
                    Mensage = "CPF invalido",
                    Erro = true
                });
            }

            Console.WriteLine("CPF Valido");

            if (!Ferramenta.ValidaIdade(t1.DataNascimento))
            {
                return BadRequest(new
                {
                    Mensage = "Idade Insuficiente",
                    Erro = true
                });
            }

            if (!Ferramenta.ValidaSexo(t1.Sexo))
            {
                return BadRequest(new
                {
                    Mensage = "Sexo deve ser 'M' para masculino, ou 'N' para feminino.",
                    Erro = true
                });
            }          
            
            using (var context = new ProfissionalContext())
            {
                                
                var p1 = context.Profissional.Where(b => b.NomeCompleto == t1.NomeCompleto);
                //Console.WriteLine($"NUM {p1.Count()}  {p1}");

                if (p1.Count() == 0)
                {
                    t1.DataCriacao = DateTime.Now;


                    context.Profissional.Add(t1);
                    context.SaveChanges();
                }
                else
                {
                    return BadRequest(new
                    {
                        Mensage = "Nome já cadastrado. Use outro nome.",
                        Erro = true
                    });
                }
                
                Console.WriteLine($"Profissional criado {t1}");
            }

            return Ok(); //mudar para cod 201;

        }

        //DELETE-PROFISSIONAL
        [HttpDelete("/profissional/{id}")]
        public IActionResult DeleteProfissional(int id)
        {
            Console.WriteLine($"Deletar id {id}");

            using (var context = new ProfissionalContext())
            {
                Profissional p1 = context.Profissional.First(c => c.Id.Equals(id));

                if(p1 != null)
                {
                    context.Profissional.Remove(p1);
                    context.SaveChanges();
                }
                else
                {
                    return BadRequest(new
                    {
                        Mensage = "Id não encontrado.",
                        Erro = true
                    });
                }
                
                Console.WriteLine($"REMOVIDO {p1}");

            }

            return Ok(); //mudar para cod del;
        }

        
    }
}