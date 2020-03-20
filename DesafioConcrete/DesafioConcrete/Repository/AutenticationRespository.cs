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
            try
            {
                if (Get_Find_Email(login.email) != true)
                {
                    using (var db = new LoginContext())
                    {
                        db.CreateLogins.Add(new CreateLogin
                        {
                            nome = login.nome,
                            email = login.email,
                            senha = login.senha,
                            Token = login.Token,
                            contato = login.contato,
                            ultimo_login = DateTime.Now,
                            data_criacao = DateTime.Now
                        });
                        db.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Get_Find_Email(string email)
        {
            //Verificando se existe e-mail em banco
            try
            {
                using (var db = new LoginContext())
                {
                    return db.CreateLogins.Any(x => x.email == email);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int Get_Find_Token(string token)
        {
            //Verificando se existe e-mail em banco
            try
            {
                using (var db = new LoginContext())
                {
                    return db.CreateLogins.Where(x => x.Token == token)
                        .Select(s => s.id).FirstOrDefault<int>();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public CreateLogin Get_Find_Login(string email, string password)
        {
            //Verificando se existe e-mail em banco 
            try
            {
                using (var db = new LoginContext())
                {
                    if (db.CreateLogins.Any(x => x.email == email && x.senha == password))
                    {
                        var Data = db.CreateLogins.Where(x => x.email == email && x.senha == password)
                     .Select(o => new CreateLogin
                     {
                         id = o.id,
                         data_criacao = o.data_criacao,
                         ultimo_login = o.ultimo_login,
                         Token = o.Token
                     });
                        return Data.FirstOrDefault<CreateLogin>();
                    }
                    return null;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CreateLogin Get_Profile(long iduser,string token)
        {
            //Verificando Token associado ao usuário
            try
            {
                using (var db = new LoginContext())
                {
                    var Data = db.CreateLogins.Where(x => x.Token == token && x.id==iduser)
                         .Select(o => new CreateLogin
                         {
                             id = o.id,
                             nome = o.nome,
                             senha = o.senha,
                             email = o.email,
                             data_atualizacao = o.data_atualizacao,
                             contato = o.contato,
                             data_criacao = o.data_criacao,
                             ultimo_login = o.ultimo_login,
                             Token = o.Token
                         });
                    return Data.FirstOrDefault<CreateLogin>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public bool Put_UltimoLogin(long id)
        {
            try
            {
                using (var db = new LoginContext())
                {
                    var DataUpdata = db.CreateLogins.SingleOrDefault(x => x.id == id);
                    if (DataUpdata != null)
                    {
                        DataUpdata.ultimo_login = DateTime.Now.Date;
                        db.SaveChanges();
                    }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}