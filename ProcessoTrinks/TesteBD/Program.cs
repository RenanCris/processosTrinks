using Entidades;
using Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBD
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProcDBContext rep = new ProcDBContext()) {
                Console.WriteLine("Iniciando inserts");

                var listaComarca = new List<Comarca>()
                {
                    new Comarca(){ Descricao = "Rio de Janeiro", UF = "RJ"},
                    new Comarca(){ Descricao = "São Paulo", UF = "SP"},
                    new Comarca(){ Descricao = "Minas Gerais", UF = "MG"},
                    new Comarca(){ Descricao = "Amazonas", UF = "AM"}
                };

                var listaOj = new List<OrgaoJulgador>()
                {
                    new OrgaoJulgador(){ Descricao = "Vara Cível", Numero =1, Sigla = "VC" },
                    new OrgaoJulgador(){ Descricao = "Vara do Trabalho", Numero =1, Sigla = "VT" }
                };

                listaComarca.ForEach(x => rep.Comarcas.Add(x));
                listaOj.ForEach(x => rep.OrgaoJulgadores.Add(x));

                var listaCliente = new List<Cliente>()
                {
                    new Cliente(){ CNPJ = "00000000001", Nome = "Empresa A", UF = "RJ" },
                    new Cliente(){ CNPJ = "00000000001", Nome = "Empresa B", UF ="SP" }
                };

                listaCliente.ForEach(x => rep.Clientes.Add(x));

                var processoEmpresaA = new List<Processo>()
                {
                    new Processo(){ Status = "ativo", NumeroProcessoCNJ = "00001CIVELRJ", Comarca = listaComarca[0], ValorCausa = 200000, DataCriacao = Convert.ToDateTime("2007-10-10"), Cliente = listaCliente[0] },
                    new Processo(){ Status = "ativo", NumeroProcessoCNJ = "00002CIVELSP", Comarca = listaComarca[1], ValorCausa = 100000, DataCriacao = Convert.ToDateTime("2007-10-20"), Cliente = listaCliente[0] },
                    new Processo(){ Status = "inativo", NumeroProcessoCNJ = "00003TRABMG", Comarca = listaComarca[2], ValorCausa = 10000, DataCriacao = Convert.ToDateTime("2007-10-30"), Cliente = listaCliente[0] },
                    new Processo(){ Status = "inativo", NumeroProcessoCNJ = "00004CIVELRJ", Comarca = listaComarca[0], ValorCausa = 20000, DataCriacao = Convert.ToDateTime("2007-11-10"), Cliente = listaCliente[0] },
                    new Processo(){ Status = "ativo", NumeroProcessoCNJ = "00005CIVELSP", Comarca = listaComarca[1], ValorCausa = 35000, DataCriacao = Convert.ToDateTime("2007-11-15"), Cliente = listaCliente[0] },
                };

                processoEmpresaA.ForEach(x => rep.Processos.Add(x));

                var processoEmpresaB = new List<Processo>()
                {
                    new Processo(){ Status = "ativo", NumeroProcessoCNJ = "00006CIVELRJ", Comarca = listaComarca[0], ValorCausa = 20000, DataCriacao = Convert.ToDateTime("2007-05-01"), Cliente = listaCliente[1] },
                    new Processo(){ Status = "ativo", NumeroProcessoCNJ = "00007CIVELSP", Comarca = listaComarca[0], ValorCausa = 700000, DataCriacao = Convert.ToDateTime("2007-06-02"), Cliente = listaCliente[1] },
                    new Processo(){ Status = "inativo", NumeroProcessoCNJ = "00008CIVELSP", Comarca = listaComarca[1], ValorCausa = 500, DataCriacao = Convert.ToDateTime("2007-07-03"), Cliente = listaCliente[1] },
                    new Processo(){ Status = "ativo", NumeroProcessoCNJ = "00009CIVELSP", Comarca = listaComarca[1], ValorCausa = 32000, DataCriacao = Convert.ToDateTime("2007-08-04"), Cliente = listaCliente[1] },
                    new Processo(){ Status = "inativo", NumeroProcessoCNJ = "00010TRABAM", Comarca = listaComarca[3], ValorCausa = 1000, DataCriacao = Convert.ToDateTime("2007-09-05"), Cliente = listaCliente[1] },
                };

                processoEmpresaB.ForEach(x => rep.Processos.Add(x));

                rep.SaveChanges();

            }
        }
    }
}
