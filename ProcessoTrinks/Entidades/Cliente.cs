using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }

        public virtual ICollection<Processo> ProcessosCliente { get; set; }

        public Cliente()
        {
            this.ProcessosCliente = new List<Processo>();
        }
    }
}
