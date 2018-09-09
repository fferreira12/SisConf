using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;

namespace SisConfTestes.Funcionalidade
{
    [TestClass()]
    public class TestFuncionalidade
    {
        [TestMethod]
        public void TestCriacaoDeEstoqueInicial()
        {
            Estoque e = new Estoque("Estoque Principal");

            Insumo insumo1 = new Insumo("Farinha de Trigo");
            Insumo insumo2 = new Insumo("Leite");
            Insumo insumo3 = new Insumo("Ovos");
            Insumo insumo4 = new Insumo("Cenoura");

            Marca marca1 = new Marca("Dona Benta");
            insumo1.Marca = marca1;
            insumo2.Marca = marca1;
            insumo3.Marca = marca1;

            List<Insumo> insumosMarca1 = marca1.ObterInsumos();

            Aquisicao aq1 = new Aquisicao(insumo1, 10, 3.5);
            Aquisicao aq2 = new Aquisicao(insumo2, 10, 3.5);
            Aquisicao aq3 = new Aquisicao(insumo3, 12, 0.5);
            Aquisicao aq4 = new Aquisicao(insumo4, 5, 3.0);

            e.IncluirAquisicao(aq1, aq2, aq3, aq4);

            Assert.AreEqual(10*3.5+10*3.5+12*0.5+5*3, e.ValorTotalDoEstoque());

            Produto p1 = new Produto();
            p1.Nome = "Bolo de Cenoura";
            p1.IncluirInsumo(insumo1, 0.3);
            p1.IncluirInsumo(insumo2, 0.5);
            p1.IncluirInsumo(insumo3, 3);
            p1.IncluirInsumo(insumo4, 1);

            double custoP1 = p1.CalcularCustoDoProduto(e);
            
        }

        [TestMethod]
        public void TestCriacaoDeEncomenda()
        {
            Cliente cliente = new Cliente()
            {
                CPF = "000.000.000-00",
                DataDeNascimento = new DateTime(1992, 8, 4),
                Descricao = "Filho de Fulana",
                Nome = "Fernando",
                Sobrenome = "Ferreira",
                Sexo = Sexo.MASCULINO,
                TipoCliente = TipoCliente.PESSOA_FISICA
            };

            Endereco endereco = new Endereco()
            {
                Cidade = "Brazlandia",
                Estado = "DF",
                Logradouro = "Quadra 00",
                Numero = "Lote 00",
                Observacao = "Aoo lado de X"
            };

            Email email = new Email("fernando@gmail.com");

            Telefone telefone = new Telefone(61, "3333-3333");

            cliente.Adicionar(endereco);
            cliente.Adicionar(email);
            cliente.Adicionar(telefone);

            Encomenda enc = new Encomenda()
            {
                Cliente = cliente,
                DataRecebimento = new DateTime(2018, 9, 9, 15, 43, 55),
                DataHoraEntrega = new DateTime(2018, 9, 14, 20, 0, 0),
                EnderecoEntrega = cliente.ObterEnderecos()[0],
                Observacoes = "Entregar para ciclano"
            };

            Estoque estoque = new Estoque("Estoque Principal");

            Insumo i1 = new Insumo("Farinha de Trigo");
            Insumo i2 = new Insumo("Leite");
            Insumo i3 = new Insumo("Ovo");
            Insumo i4 = new Insumo("Óleo");
            Insumo i5 = new Insumo("Leite Condensado");
            Insumo i6 = new Insumo("Manteiga");
            Insumo i7 = new Insumo("Leite Ninho");

            Aquisicao a1 = new Aquisicao(i1, 3, 3.49);
            Aquisicao a2 = new Aquisicao(i2, 12, 3.25);
            Aquisicao a3 = new Aquisicao(i3, 12, 4.99/12);
            Aquisicao a4 = new Aquisicao(i4, 6, 1.59);
            Aquisicao a5 = new Aquisicao(i5, 3*0.395, 2.49/0.395);
            Aquisicao a6 = new Aquisicao(i6, 0.3, 3.25/0.3);
            Aquisicao a7 = new Aquisicao(i7, 0.4, 8.99/0.4);

            estoque.IncluirAquisicao(a1, a2, a3, a4, a5, a6, a7);
            double valorEstoque = estoque.ValorTotalDoEstoque();

            Produto p1 = new Produto("Bolo de Leite Ninho");
            p1.IncluirInsumo(i1, 0.3);
            p1.IncluirInsumo(i2, 0.4);
            p1.IncluirInsumo(i3, 3.0);
            p1.IncluirInsumo(i4, 0.2);
            p1.IncluirInsumo(i5, 0.3);
            p1.IncluirInsumo(i6, 0.3);
            p1.IncluirInsumo(i7, 0.1);

            double custoProduto = p1.CalcularCustoDoProduto(estoque);
            double precoDeVenda = p1.ObterPrecoDeVendaPelaMargemDeLucro(0.4);
            double precoDeVenda2 = p1.ObterPrecoDeVendaPeloLucroAbsoluto(20);

            double lucro1 = precoDeVenda - custoProduto;
            double lucro2 = precoDeVenda2 - custoProduto;
            double margemLucro2 = lucro2 / precoDeVenda2;
        }
    }
}
