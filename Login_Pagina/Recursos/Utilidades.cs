using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace Login_Pagina.Recursos
{
    public class Utilidades
    {
        public static string EncriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 HASH = SHA256Managed.Create()) 
            {
                Encoding enc= Encoding.UTF8;

                byte[] result = HASH.ComputeHash(enc.GetBytes(clave));
                foreach (byte b in result) 
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
