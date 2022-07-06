using DesafioAPI.Model;
using System.Data.Entity;

namespace DesafioAPI.Data
{
    public class ProfissionalContext: DbContext
    {
        public DbSet <Profissional> Profissional { get; set; }
    }
}
