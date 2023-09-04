using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Models
{
    public class AlterarSenhaModel
    {
        public string Username { get; set; }
        public string SenhaAtual { get; set; }
         public string NovaSenha { get; set; }
    }

}