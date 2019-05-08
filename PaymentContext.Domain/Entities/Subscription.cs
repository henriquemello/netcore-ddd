using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities{
    public class Subscription: Shared.Entities.Entity
    {

        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get{ return _payments.ToArray();} }

        public void AddPayment(Payment payment){

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now,payment.PaidDate,"Subscription.Payments","A data do pagamento deve ser futura")
            );
            
            //if(Valid) só adiciona se for válido.
            _payments.Add(payment);
            
        }
        public void ChangeActive(bool activate){
            Active = activate;
            LastUpdateDate = DateTime.Now;
        } 

    }
}