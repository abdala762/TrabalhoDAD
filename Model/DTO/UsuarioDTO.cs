using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UsuarioDTO
    {
        public string cpf { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
        public int tentativas { get; set; }
        public bool bloqueado { get; set; }

    }
}

