using DesafioConcrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioConcrete.Repository
{
    public class AutenticationRespository
    {
        public bool Post_Create_Login(CreateLogin login)
        {
            //Criando conta em banco de dados
            return true;
        }
        public bool Get_Find_Email(string email)
        {
            //Verificando se existe e-mail em banco
            return false
;
        }
        public bool Get_Find_Token(long id,string token)
        {
            return true;
        }
        public CreateLogin Get_Find_Login(string email,string password)
        {
            return new CreateLogin();
        }
        public CreateLogin Get_Profile(long id, string token)
        {
            if(Get_Find_Token(id,token))
            return new CreateLogin();

            return null;
        }
        public bool Put_UltimoLogin(long id)
        {
            return false;
        }
    }


}
