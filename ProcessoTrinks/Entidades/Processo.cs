using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Processo
    {
        public int IdProcesso { get; set; }
        public string NumeroProcessoCNJ { get; set; }
        public virtual Comarca Comarca { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal ValorCausa { get; set; }
        public virtual OrgaoJulgador OJ { get; set; }
        public Cliente Cliente { get; set; }
        public string Status { get; set; }
    }
}
