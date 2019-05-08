using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests{

    [TestClass]
    public class StudentTests
    {
     
        public readonly Name _name;
        public readonly Document _document;
        public readonly Email _mail;
        public readonly Address _address;
        public readonly Student _student;
        public readonly Subscription _subscription;


        public StudentTests()
        {
            _name = new Name("Tony","Stark");
            _document = new Document("12312312333",EDocumentType.CPF);
            _mail = new Email("tony@starkindustries.com");
            _address = new Address("rua 12","33","Bairro X","Sumaré City","SP","Brasil","123123-223");   
            _student = new Student(_name,_document,_mail); 
            _subscription = new Subscription(null);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {   
            var payment = new PayPalPayment("1232132",DateTime.Now,DateTime.Now.AddDays(5),10,10,"Stark Industries",_document,_address,_mail);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        // [TestMethod]
        // public void ShouldReturnErrorWhenSubscriptionsHasNoPayments(){

        //     _student.AddSubscription(_subscription);

        //     Assert.IsTrue(_student.Invalid);
        // }

        // [TestMethod]
        // public void ShouldReturnSuccessWhenAddSubscription()
        // {   
        //     var payment = new PayPalPayment("1232132",DateTime.Now,DateTime.Now.AddDays(5),10,10,"Stark Industries",_document,_address,_mail);

        //     _subscription.AddPayment(payment);
        //     _student.AddSubscription(_subscription);

        //     Assert.IsTrue(_student.Valid);
        // }
    }

}