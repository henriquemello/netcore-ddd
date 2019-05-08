using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{

    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();



            command.FirstName = "Tony";
            command.LastName = "Stark";
            command.Document = "99999999999";
            command.Email = "henrique@gmail.com";
            command.BarCode = "221312322";
            command.BoletoNumber = "11222";
            command.PaymentNumber = "1111";
            command.PaidDate = DateTime.Now;
            command.ExpiredDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Stark Industries";
            command.PayerDocument = "123";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "tony@starkinc.com";
            command.Street = "11123";
            command.Number = "222";
            command.Neighborhood = "Bairro";
            command.City = "Campinas";
            command.State = "SP";
            command.Country = "Brasil";
            command.ZipCode = "123333223";


            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);

        }
    }
}