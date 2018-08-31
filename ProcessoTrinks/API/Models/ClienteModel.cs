using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
    }
}