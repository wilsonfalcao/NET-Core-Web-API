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
        public int id { get { return 12345; } }
        public  string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Telefone contato{ get; set; }

    }

    public class Telefone
    {
        public string numero { get; set; }
        public byte ddd { get; set; }
    }
}
