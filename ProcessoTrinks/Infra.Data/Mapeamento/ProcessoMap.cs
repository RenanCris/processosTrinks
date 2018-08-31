using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mapeamento
{
    public class ProcessoMap : EntityTypeConfiguration<Processo>
    {
        public ProcessoMap()
        {
            ToTable("processo");
            HasKey(x => x.IdProcesso);
            Property(x => x.IdProcesso).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DataCriacao);
            Property(x => x.ValorCausa);
            Property(x => x.Status).HasMaxLength(25);
            Property(x => x.NumeroProcessoCNJ).HasMaxLength(25);
            HasOptional(x => x.Cliente);
        }
    }
}
