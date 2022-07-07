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

            var busca = Db.FindAll();

            busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));
                
            return ProfissionalSaida.ConverteSaida(busca);

        }

        //Busca por nome
        [HttpGet("/profissional/busca/nome/{nome}")]
        public List<ProfissionalSaida> GetByName(string nome)
        {

            List<Profissional> busca = Db.FindByName(nome);

            busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));

            return ProfissionalSaida.ConverteSaida(busca);
        }

        //Busca por registro (range)
        [HttpGet("/profissional/busca/registro/{registro}")]
        public List<ProfissionalSaida> GetByRegister(string registro)
        {

            var busca = Db.FindByRegister(registro);

            busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));

            return ProfissionalSaida.ConverteSaida(busca);
            
        }

        //Busca por ativos
        [HttpGet("/profissional/busca/ativo")]
        public List<ProfissionalSaida> GetByActivate()
        {

                List<Profissional> busca = Db.FindByActive();

                busca.Sort((x, y) => string.Compare(x.NomeCompleto, y.NomeCompleto));

                return ProfissionalSaida.ConverteSaida(busca);

        }

        //POST-PROFISSIONAL
        //FALTA autoincrement numeroRegistro;
        [HttpPost("/profissional")]
        public IActionResult PostProfissional(Profissional p1)
        {
            if (!Ferramenta.ValidaCPF(p1.CPF))
            {
                return BadRequest(
                new{
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

            if (!Ferramenta.ValidaSexo(p1.Sexo))
            {
                return BadRequest(new
                {
                    Mensage = "Sexo deve ser 'M' para masculino, ou 'N' para feminino.",
                    Erro = true
                });
            }


            var profissional = Db.CreateProfissional(p1);

            if (profissional != null)
            {
                return Ok(new { profissional }); 
            }
            else
            {
                return BadRequest(new
                {
                    Mensage = "Nome já cadastrado. Use outro nome.",
                    Erro = true
                });
            }
        }

        //Editar
        [HttpPut("/profissional/{id}")]
        public IActionResult Edit(int id, Profissional p1)
        {

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

            var profissional = Db.EditProfissional(id, p1);
            
            return Ok(new { profissional });

        }
        

        //DELETE-PROFISSIONAL
        [HttpDelete("/profissional/{id}")]
        public IActionResult DeleteProfissional(int id)
        {

            var profissional = Db.DeleteProfissional(id);

            if(profissional != null)
            {
                return Ok(new { profissional });
            }
            else
            {
                return BadRequest(new
                {
                    Mensage = "Id não encontrado.",
                    Erro = true
                });
            }
            
        }

        
    }
}