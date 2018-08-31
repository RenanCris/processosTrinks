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
    public class OrgaoJulgadorMap: EntityTypeConfiguration<OrgaoJulgador>
    {
        public OrgaoJulgadorMap()
        {
            ToTable("oj");
            HasKey(x => x.IdOj);
            Property(x=> x.IdOj).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Numero).IsRequired();
            Property(x=> x.Sigla).HasMaxLength(6).IsRequired()
                .HasColumnAnnotation("idxSiglaOj", new IndexAnnotation(new[] {
                    new IndexAttribute("idxSiglaOj") { IsUnique = true } }));

        }
    }
}
