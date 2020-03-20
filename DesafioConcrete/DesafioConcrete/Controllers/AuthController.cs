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
        public ActionResult SingUp([FromBody] CreateLogin CadastroUser)
        {
            CadastroUser.data_criacao = DateTime.Now;
            CadastroUser.ultimo_login = DateTime.Now;
            if (_repo.Get_Find_Email(CadastroUser.email) != true)
            {
                //Gerando Token
                CadastroUser.Token = new CreateToken().GetToken;
                //Gravando conta em banco
                if (_repo.Post_Create_Login(CadastroUser))
                {
                    //LoginUser.Token = new StringToHash().GetHash(LoginUser.Token);

                    //
                    return SucessCreateLogin(CadastroUser);
                }
                else
                {
                    return HttpStatusCodeResult(404, "Erro no banco de dados");
                }
            }
            else
            {
                //Retorno Not Found
                return HttpStatusCodeResult(404, "E-mail já existe no banco");
            }

        }
        private ActionResult SucessCreateLogin(CreateLogin LoginUser)
        {
            //Gerando Json de Registro do Dado
            var JsonData = new
            {
                id = _repo.Get_Find_Token(LoginUser.Token),
                data_criacao = LoginUser.data_criacao,
                ultimo_login = LoginUser.ultimo_login,
                token = LoginUser.Token
            };

            //Retornando Dados para Wep API
            return new JsonResult(JsonData);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] DataLogin LoginAuthen)
        {
            CreateLogin Body_Login = new CreateLogin();
            Body_Login = _repo.Get_Find_Login(LoginAuthen.email, LoginAuthen.senha);
            if (Body_Login != null)
            {
                Ultimo_Login(Body_Login.id);
                return SucessCreateLogin(Body_Login);
            }
            else
            {
                return HttpStatusCodeResult(401, "Usuário e/ou senha não batem");
            }
        }

        [HttpGet("profile")]
        [Authorize]
        public ActionResult Profile()
        {
            long IdUser = _repo.Get_Find_Token(Request.Headers["Token"].ToString());
            if (IdUser != 0)
            return SucessProfile(_repo.Get_Profile(IdUser,Request.Headers["Token"].ToString()));

            return HttpStatusCodeResult(401, "Não Autorizado");
        }
        private ActionResult SucessProfile(CreateLogin LoginUser)
        {
            //Gerando Json de Registro do Dado
            var JsonData = new
            {
                id = LoginUser.id,
                nome = LoginUser.nome,
                email = LoginUser.email,
                senha= new StringToHash().GetHash(LoginUser.senha),
                data_criacao = LoginUser.data_criacao,
                data_atualizacao = LoginUser.data_atualizacao,
                ultimo_login = LoginUser.ultimo_login,
                token = LoginUser.Token
            };

            //Retornando Dados para Wep API
            return new JsonResult(JsonData);
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
            _repo.Put_UltimoLogin(Id);
        }
    }
}
