using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace CapaComun
{
    /* 
    Esta clase contiene funciones para encriptar/desencriptar
    Al ser estática no es necesario instanciar un objeto para 
    usar las funciones Encriptar y DesEncriptar
    Contiene 3 Metodos, los dos primeros (Encriptar - Desencriptar)
    Codifican y decodifican un texto plano en base de 64 
    El tercer metodo ENCRIPTA utilizando Hash. Hay que tener en cuenta 
    que todos los metodos HASH (MD5 - SHA1 - SHA256 etc) SON DE UN SOLO SENTIDO
    es decir que no pueden desencriptarse.
    */

    public static class clsSeguridad
    {
        // Encripta una cadena
        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        // Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string SHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
