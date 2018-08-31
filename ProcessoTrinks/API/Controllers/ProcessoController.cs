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
    [RoutePrefix("processo")]
    public class ProcessoController : ApiController
    {
        IProcessoRepository processoRep;

        public ProcessoController(IProcessoRepository processoRep)
        {
            this.processoRep = processoRep;
        }

        [Route("v1/criar")]
        [HttpPost]
        public IHttpActionResult Criar(ProcessoModel processoModel) {
            try
            {
                var processo = new Processo() {
                    Comarca = this.processoRep.GetComarcaPorId(processoModel.IdComarca),
                    OJ = this.processoRep.GetOrgaoJulgadorPorId(processoModel.IdOJ),
                    DataCriacao = processoModel.DataCriacao,
                    NumeroProcessoCNJ = processoModel.NumeroProcessoCNJ,
                    Status = processoModel.Status,
                    ValorCausa = processoModel.ValorCausa
                };

                this.processoRep.AddProcesso(processo);

                return Ok("Processo criado");

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/getSomaProcessosAtivos")]
        public IHttpActionResult GetSomaProcessosAtivos()
        {
            try
            {
                return Ok(this.processoRep.GetSomaProcessosAtivos());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/calcularValorMedioPorLocalizacaoECliente/{local}/{nomeCliente}")]
        public IHttpActionResult CalcularValorMedioPorLocalizacaoECliente(string local, string nomeCliente)
        {
            try
            {
                return Ok(this.processoRep.CalcularValorMedioPorLocalizacaoECliente(local, nomeCliente));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/getProcessosComValorAcima/{valor}")]
        public IHttpActionResult GetProcessosComValorAcima(decimal valor)
        {
            try
            {
                return Ok(this.processoRep.GetProcessosComValorAcima(valor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/GetProcessoPorData/{data}")]
        public IHttpActionResult GetProcessoPorData(DateTime data)
        {
            try
            {
                return Ok(this.processoRep.GetProcessoPorData(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/getProcessosMesmoEstadoCliente/{nomeCliente}")]
        public IHttpActionResult GetProcessosMesmoEstadoCliente(string nomeCliente)
        {
            try
            {
                return Ok(this.processoRep.GetProcessosMesmoEstadoCliente(nomeCliente));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/getProcessosContenhaSiglaNProcesso/{sigla}")]
        public IHttpActionResult GetProcessosContenhaSiglaNProcesso(string sigla)
        {
            try
            {
                return Ok(this.processoRep.GetProcessosContenhaSiglaNProcesso(sigla));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/getTodasComarca")]
        public IHttpActionResult GetComarca()
        {
            try
            {
                return Ok(this.processoRep.GetTodasComarca());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("v1/getTodosOjs")]
        public IHttpActionResult GetOjs()
        {
            try
            {
                return Ok(this.processoRep.GetJulgadores());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
