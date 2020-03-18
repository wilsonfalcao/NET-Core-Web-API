using DesafioConcrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioConcrete.Repository
{
    public class AutenticationRespository
    {
        public AutenticationRespository()
        {

        }

        public CreateLogin GetAll()
        {
            CreateLogin SetDataContact = new CreateLogin();
            SetDataContact.nome = "Wilson Falcãoo";
            SetDataContact.senha = "123@@";
            SetDataContact.contato.ddd = 81;
            SetDataContact.contato.numero = "99987-9940";

            return SetDataContact;
        }
    }


}
