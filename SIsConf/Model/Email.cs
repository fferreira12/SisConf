using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Email
    {
        public int Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Provedor { get; set; }

        public Email() { }
        public Email(string emailCompleto)
        {
            string[] parts = emailCompleto.Split('@');
            if(parts.Count() == 2)
            {
                NomeDeUsuario = parts[0];
                Provedor = parts[1];
            }
            
        }
        public Email(string nomeDeUsuario, string provedor)
        {
            NomeDeUsuario = nomeDeUsuario;
            Provedor = provedor;
        }

        public string EmailCompleto()
        {
            return NomeDeUsuario + "@" + Provedor;
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
