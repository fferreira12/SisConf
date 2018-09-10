using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Descricao { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public TipoCliente TipoCliente { get; set; }

        private List<Endereco> enderecos;
        private List<Telefone> telefones;
        private List<Email> emails;

        public List<Endereco> ObterEnderecos()
        {
            return new List<Endereco>(enderecos);
        }

        public List<Telefone> ObterTelefones()
        {
            return new List<Telefone>(telefones);
        }

        public List<Email> ObterEmails()
        {
            return new List<Email>(emails);
        }

        public Cliente()
        {
            enderecos = new List<Endereco>();
            telefones = new List<Telefone>();
            emails = new List<Email>();
        }

        public void Adicionar(Endereco endereco)
        {
            enderecos.Add(endereco);
        }

        public void Remover(Endereco endereco)
        {
            enderecos.Remove(endereco);
        }

        public void Adicionar(Telefone telefone)
        {
            telefones.Add(telefone);
        }

        public void Remover(Telefone telefone)
        {
            telefones.Remove(telefone);
        }

        public void Adicionar(Email email)
        {
            if(Email.ValidarEmail(email.EmailCompleto()))
            {
                emails.Add(email);
            }
        }

        public void Remover(Email email)
        {
            emails.Remove(email);
        }
    }
}
