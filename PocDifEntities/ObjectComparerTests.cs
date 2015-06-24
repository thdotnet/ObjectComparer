using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocDifEntities.Entity;
using PocDifEntities.LIB;

namespace PocDifEntities
{
    [TestClass]
    public class ObjectComparerTests
    {
        [TestMethod]
        public void GivenTwoObjects_WhenComparing_ShouldReturnDiferences()
        {
            var usuario = new User
            {
                Id = 1,
                Birthday = new DateTime(1987, 9, 10),
                Email = "th@fakedomain.com.br",
                Name = "Thiago Custodio",
                Telephone = "551198989-1234",
                Twitter = "@thdotnet",
                Address = new Address
                {
                    ZipCode = "04242-042",
                    City = "São Paulo",
                    Address2 = "apto",
                    State = "SP",
                    Street = "Rua da minha casa",
                    AddressNumber = "123",
                }
            };

            var usuario2 = new User
            {
                Id = 1,
                Birthday = new DateTime(1987, 9, 10),
                Email = "th2@fakedomain.com.br",
                Name = "Thiago Custodio",
                Telephone = "551198989-1234",
                Nickname = "thdotnet",
                Address = new Address
                {
                    ZipCode = "04246-046",
                    City = "São Paulo",
                    Address2 = "apto",
                    State = "SP",
                    Street = "Rua da minha casa",
                    AddressNumber = "123"
                }
            };

            var result = ObjectComparer.Compare<User>(usuario, usuario2);

            int quantityExpected = 4;

            string currentEmail = "th2@fakedomain.com.br";
            string currentCep = "04246-046";
            string currentApelido = "thdotnet";
            string currentTwitter = "";

            Assert.AreEqual(quantityExpected, result.Count);

            Assert.AreEqual(currentEmail, result["Email"].CurrentValue);
            Assert.AreEqual(currentCep, result["ZipCode"].CurrentValue);
            Assert.AreEqual(currentApelido, result["Nickname"].CurrentValue);
            Assert.AreEqual(currentTwitter, result["Twitter"].CurrentValue);
        }
    }
}
