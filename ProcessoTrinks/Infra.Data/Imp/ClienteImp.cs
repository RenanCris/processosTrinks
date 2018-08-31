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
    public class ClienteImp : IClienteRepository
    {
        public readonly ProcDBContext repository;

        public ClienteImp(ProcDBContext repository)
        {
            this.repository = repository;
        }

        public void AddCliente(Cliente cliente)
        {
            repository.Clientes.Add(cliente);
            repository.SaveChanges();
        }
    }
}
