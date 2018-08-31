using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mapeamento
{
    public class ComarcaMap : EntityTypeConfiguration<Comarca>
    {
        public ComarcaMap()
        {
            ToTable("comarca");
            HasKey(x => x.IdComarca);
            Property(x => x.IdComarca).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnAnnotation("idxcomarca", new IndexAnnotation(new[] {
                    new IndexAttribute("idxcomarca") { IsUnique = true } }));

            Property(x => x.UF).HasColumnName("uf")
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
