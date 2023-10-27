using System.Security.Cryptography;
using System.Text;

namespace AvaliacaoSesab.Helper
{
    public static class Cryptography
    {
        public static string CreateHash(string valor)
        {
            var hash = SHA1.Create();
            var encode = new ASCIIEncoding();
            var array = encode.GetBytes(valor);

            array = hash.ComputeHash(array);
            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }
    }
}
