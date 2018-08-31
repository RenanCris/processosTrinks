using Dominio.Contratos;
using Entidades;
using Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Imp
{
    public class ProcessoImp : IProcessoRepository
    {
        public readonly ProcDBContext repository;

        public ProcessoImp(ProcDBContext repository)
        {
            this.repository = repository;
        }

        public void AddProcesso(Processo processo)
        {
            repository.Processos.Add(processo);
            repository.SaveChanges();
        }

        public decimal CalcularValorMedioPorLocalizacaoECliente(string local, string cliente)
        {
           return repository.Processos.Include("Comarca").Include("Cliente")
                .Where(p => p.Comarca.Descricao.Equals(local) 
                    && p.Cliente.Nome.Equals(cliente)
                ).Average(z => z.ValorCausa);
        }

        public Comarca GetComarcaPorId(int id)
        {
            return repository.Comarcas.Where(c => c.IdComarca.Equals(id)).FirstOrDefault();
        }

        public ICollection<OrgaoJulgador> GetJulgadores()
        {
            return this.repository.OrgaoJulgadores.ToList();
        }

        public OrgaoJulgador GetOrgaoJulgadorPorId(int id)
        {
            return repository.OrgaoJulgadores.Where(c => c.IdOj.Equals(id)).FirstOrDefault();
        }

        public ICollection<Processo> GetProcessoPorData(DateTime data)
        {
            return repository.Processos.Where(p => p.DataCriacao.Year == data.Year
            && p.DataCriacao.Month == data.Month
            ).ToList();
        }

        public int GetProcessosComValorAcima(decimal valor)
        {
            return repository.Processos.Where(p => p.ValorCausa > valor).Count();
        }

        public ICollection<Processo> GetProcessosContenhaSiglaNProcesso(string sigla)
        {
            return repository.Processos.Include("Comarca")
                .Where(p => p.NumeroProcessoCNJ.Contains(sigla)
                ).ToList();
        }

        public ICollection<string> GetProcessosMesmoEstadoCliente(string cliente)
        {
            var EstadoCliente = repository.Clientes.Where(c => c.Nome.Equals(cliente)).FirstOrDefault();

            var processos = repository.Processos.Include("Cliente")
                 .Where(p => p.Comarca.UF.Equals(EstadoCliente.UF)
                 && p.Cliente.Nome.Equals(cliente)
                 ).Select(x=> x.NumeroProcessoCNJ).ToList();

            return processos;
        }

        public decimal GetSomaProcessosAtivos()
        {
            return repository.Processos.Where(p => p.Status.Equals("ativo")).Sum(v => v.ValorCausa);
        }

        public ICollection<Comarca> GetTodasComarca()
        {
            return repository.Comarcas.ToList();
        }
    }
}
