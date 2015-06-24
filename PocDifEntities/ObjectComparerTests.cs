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
            var user1 = new User
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

            var user2 = new User
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

            var result = ObjectComparer.Compare<User>(user1, user2);

            int quantityExpected = 4;

            string currentEmail = "th2@fakedomain.com.br";
            string currentZipCode = "04246-046";
            string currentNickName = "thdotnet";
            string currentTwitter = "";

            Assert.AreEqual(quantityExpected, result.Count);

            Assert.AreEqual(currentEmail, result["Email"].CurrentValue);
            Assert.AreEqual(currentZipCode, result["ZipCode"].CurrentValue);
            Assert.AreEqual(currentNickName, result["Nickname"].CurrentValue);
            Assert.AreEqual(currentTwitter, result["Twitter"].CurrentValue);
        }
    }
}
