using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface IProcessoRepository {
        decimal GetSomaProcessosAtivos();
        decimal CalcularValorMedioPorLocalizacaoECliente(string local, string cliente);
        int GetProcessosComValorAcima(decimal valor);
        ICollection<Processo> GetProcessoPorData(DateTime data);
        ICollection<string> GetProcessosMesmoEstadoCliente(string cliente);
        ICollection<Processo> GetProcessosContenhaSiglaNProcesso(string sigla);
        void AddProcesso(Processo processo);

        Comarca GetComarcaPorId(int id);
        OrgaoJulgador GetOrgaoJulgadorPorId(int id);

        ICollection<Comarca> GetTodasComarca();
        ICollection<OrgaoJulgador> GetJulgadores();

    }
}
