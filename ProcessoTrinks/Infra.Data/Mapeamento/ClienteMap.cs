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
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("cliente");
            HasKey(x => x.IdCliente);
            Property(x => x.IdCliente).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CNPJ).HasMaxLength(14)
                 .IsRequired()
                 .HasColumnAnnotation("idxcnpj", new IndexAnnotation(new[] {
                    new IndexAttribute("idxcnpj") { IsUnique = true } }));
            Property(x => x.Nome).HasMaxLength(255);
            Property(x => x.UF).HasMaxLength(2);

        }
    }
}
