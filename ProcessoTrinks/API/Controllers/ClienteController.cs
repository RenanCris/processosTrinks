using API.Models;
using Dominio.Contratos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("cliente")]
    public class ClienteController : ApiController
    {
        IClienteRepository clienteRep;

        public ClienteController(IClienteRepository clienteRep)
        {
            this.clienteRep = clienteRep;
        }

        [Route("v1/criar")]
        [HttpPost]
        public IHttpActionResult Criar(ClienteModel ClienteModel)
        {
            try
            {
                var cliente = new Cliente()
                {
                    Nome = ClienteModel.Nome,
                    CNPJ = ClienteModel.CNPJ,
                    UF = ClienteModel.UF
                };

                this.clienteRep.AddCliente(cliente);

                return Ok("Cliente criado");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
