using System.Security.Cryptography;
using System.Text;

namespace DesafioConcrete.Model
{
    public class StringToHash
    {
        public string GetHash(string Value)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(Value));
            }
            return hash.ToString();
        }
    }
}
