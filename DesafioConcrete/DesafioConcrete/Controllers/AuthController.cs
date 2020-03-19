using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioConcrete.Repository;
using DesafioConcrete.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DesafioConcrete.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        private AutenticationRespository _repo;
        public authController()
        {
            AutenticationRespository Data_Autentication = new AutenticationRespository();
            _repo = Data_Autentication;
        }
        [HttpPost("singup")]
        public ActionResult SingUp()
        {
            //Setando Valores para Criar em Banco
            CreateLogin LoginUser = new CreateLogin()
            {
                nome = "Wilson",
                email = "Wilson.falcao1@hotmail.com",
                senha = "123456",
                contato = new Telefone() { ddd=81,numero="99987-9940"},
                data_criacao = DateTime.Now.Date,
                data_atualizacao= DateTime.Now.Date,
                ultimo_login = DateTime.Now.Date
            };
            //Verificando se há e-mails iguais
            if (_repo.Get_Find_Email(LoginUser.email)!=true)
            {
                //Gerando Token
                LoginUser.Token = new CreateToken().GetToken;
                //Gravando conta em banco
                if(_repo.Post_Create_Login(LoginUser))
                { 
                //LoginUser.Token = new StringToHash().GetHash(LoginUser.Token);

                //
                return SucessCreateLogin(LoginUser);
                }
                else
                {
                    return HttpStatusCodeResult(404, "Erro no banco de dados");
                }
            }
            else
            {
                //Retorno Not Found
                return HttpStatusCodeResult(404,"E-mail já existe no banco");
            }
        }
        private ActionResult SucessCreateLogin(CreateLogin LoginUser)
        {
            //Gerando Json de Registro do Dado
            var JsonData = new
            {
                id = LoginUser.id,
                data_criacao = LoginUser.data_criacao,
                ultimo_login = LoginUser.ultimo_login,
                token = LoginUser.Token
            };

            //Retornando Dados para Wep API
            return new JsonResult(JsonData);
        }

        [HttpPost("login")]
        //Necessita colocar Hash no parametro senha
        public ActionResult Login(string email, string senha)
        {
            CreateLogin Body_Login = new CreateLogin();
            Body_Login = _repo.Get_Find_Login(email, senha);
            if (Body_Login != null)
            {
                return SucessCreateLogin(Body_Login);
            }
            else
            {
                return HttpStatusCodeResult(401, "Usuário e/ou senha não batem");
            }
        }

        [HttpGet("profile")]
        public CreateLogin Profile(long id)
        {
            return _repo.Get_Profile(id, "");
        }
        private ActionResult HttpStatusCodeResult(int Erro, string Mensagem)
        {
            return new JsonResult(new {
                statuscode = 0+", "+Erro,
                mesagem = Mensagem
            });
        }
        private void Ultimo_Login(long Id)
        {
            _repo.Put_UltimoLogin(0);
        }
    }
}
