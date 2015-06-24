using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PocDifEntities.cs
{
    [TestClass]
    public class ObjectComparerTests
    {
        [TestMethod]
        public void GivenTwoObjects_WhenComparing_ShouldReturnDiferences()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Cep = "04242-042",
                Cidade = "São Paulo",
                Complemento = "apto",
                DataNascimento = new DateTime(1987, 9, 10),
                Email = "th@fakedomain.com.br",
                Estado = "SP",
                Logradouro = "Rua da minha casa",
                Nome = "Thiago Custodio",
                Numero = "123",
                Telefone = "551198989-1234",
                Twitter = "@thdotnet"
            };

            var usuario2 = new Usuario
            {
                Id = 1,
                Cep = "04246-046",
                Cidade = "São Paulo",
                Complemento = "apto",
                DataNascimento = new DateTime(1987, 9, 10),
                Email = "th2@fakedomain.com.br",
                Estado = "SP",
                Logradouro = "Rua da minha casa",
                Nome = "Thiago Custodio",
                Numero = "123",
                Telefone = "551198989-1234",
                Apelido = "thdotnet"
            };

            var result = ObjectComparer.Compare<Usuario>(usuario, usuario2);

            int quantityExpected = 4;

            string currentEmail = "th2@fakedomain.com.br";
            string currentCep = "04246-046";
            string currentApelido = "thdotnet";
            string currentTwitter = "";

            Assert.AreEqual(quantityExpected, result.Count);

            Assert.AreEqual(currentEmail, result["Email"].ValorAtual);
            Assert.AreEqual(currentCep, result["Cep"].ValorAtual);
            Assert.AreEqual(currentApelido, result["Apelido"].ValorAtual);
            Assert.AreEqual(currentTwitter, result["Twitter"].ValorAtual);
        }
    }
}
