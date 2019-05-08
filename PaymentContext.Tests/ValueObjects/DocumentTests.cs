using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests{

    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {   
            var doc = new Document("123",EDocumentType.CNPJ);

            Assert.IsTrue(doc.Invalid);

        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {   
            var doc = new Document("34110468000150",EDocumentType.CNPJ);

            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {   
            var doc = new Document("1233",EDocumentType.CPF);

            Assert.IsTrue(doc.Invalid);
        }
        
        [TestMethod]
        [DataTestMethod]
        [DataRow("12312312300")]
        [DataRow("32323233233")]
        [DataRow("41232223231")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {   
            var doc = new Document(cpf,EDocumentType.CPF);

            Assert.IsTrue(doc.Valid);
        }
    }

}