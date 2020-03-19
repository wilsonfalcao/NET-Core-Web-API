
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DesafioConcrete.Model
{
    public class CreateToken
    {
        public CreateToken()
        {
            //Chave Primaria
            string securtity_token = "esse_faz_parte_da_string_de_criacao_do_token_de_acesso_" +
                "18_03_2020$smesk.in";

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securtity_token));

            //Gerando Credencial
            var signingCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //Criando Token
            var token = new JwtSecurityToken(
               issuer: "smesk.in",
               audience: "readers",
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: signingCredentials
                );
            //Obtendo Token
            GetToken = new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }
        public string GetToken { get; }
    }
}
