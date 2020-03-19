using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioConcrete.Model
{
    public class CreateLogin
    {
        public CreateLogin ()
        {
            this.contato = new Telefone();
        }
        public int id { get; set; } 
        public  string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Telefone contato{ get; set; }
        public DateTime data_criacao { get; set; }
        public DateTime data_atualizacao { get; set; }
        public DateTime ultimo_login { get; set; }
        public string Token { get; set; }

    }

    public class Telefone
    {
        public int id { get; set; }
        public string numero { get; set; }
        public byte ddd { get; set; }
    }
}
