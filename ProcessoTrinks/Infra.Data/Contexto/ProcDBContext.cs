using Entidades;
using Infra.Data.Mapeamento;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Contexto
{
    public class ProcDBContext : DbContext
    {
        public ProcDBContext():base("DB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer<ProcDBContext>(new ProcessoInitializer());
        }

        public DbSet<Processo> Processos { get; set; }
        public DbSet<Comarca> Comarcas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrgaoJulgador> OrgaoJulgadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ComarcaMap());
            modelBuilder.Configurations.Add(new OrgaoJulgadorMap());
            modelBuilder.Configurations.Add(new ProcessoMap());
            modelBuilder.Configurations.Add(new ClienteMap());
        }

        public class ProcessoInitializer : DropCreateDatabaseAlways<ProcDBContext> {
            protected override void Seed(ProcDBContext context)
            {
                base.Seed(context);
            }
        }
    }
}
