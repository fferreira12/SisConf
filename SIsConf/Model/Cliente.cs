using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Cliente : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Descricao { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public TipoCliente TipoCliente { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Email> Emails { get; set; }

        public List<Endereco> ObterEnderecos()
        {
            return new List<Endereco>(Enderecos);
        }

        public List<Telefone> ObterTelefones()
        {
            return new List<Telefone>(Telefones);
        }

        public List<Email> ObterEmails()
        {
            return new List<Email>(Emails);
        }

        public Cliente()
        {
            Enderecos = new List<Endereco>();
            Telefones = new List<Telefone>();
            Emails = new List<Email>();
        }

        public void Adicionar(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }

        public void Remover(Endereco endereco)
        {
            Enderecos.Remove(endereco);
        }

        public void Adicionar(Telefone telefone)
        {
            Telefones.Add(telefone);
        }

        public void Remover(Telefone telefone)
        {
            Telefones.Remove(telefone);
        }

        public void Adicionar(Email email)
        {
            if(Email.ValidarEmail(email.EmailCompleto()))
            {
                Emails.Add(email);
            }
        }

        public void Remover(Email email)
        {
            Emails.Remove(email);
        }
    }
}
