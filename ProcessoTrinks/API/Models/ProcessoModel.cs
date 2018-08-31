using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProcessoModel
    {
        public string NumeroProcessoCNJ { get; set; }
        public int IdComarca { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal ValorCausa { get; set; }
        public int IdOJ { get; set; }
        public int idCliente { get; set; }
        public string Status { get; set; }
    }
}