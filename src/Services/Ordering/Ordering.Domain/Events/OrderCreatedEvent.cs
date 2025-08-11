﻿using Common.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.NewFolder
{
    public class OrderCreatedEvent : BaseEvent
    {
        public long Id { get; private set; }
        public string UserName { get; private set; }

        public string DocumentNo { get; private set; }

        public decimal TotalPrice { get; private set; }

        public string EmailAddress { get; private set; }

        public string ShippingAddress { get; private set; }

        public string InvoiceAddress { get; private set; }

        public OrderCreatedEvent(long id,
            string userName, string documentNo,
            decimal totalPrice, string emailAddress,
            string shippingAddress, string invoiceAddress)
        {
            Id = id;
            UserName = userName;
            DocumentNo = documentNo;
            TotalPrice = totalPrice;
            EmailAddress = emailAddress;
            ShippingAddress = shippingAddress;
            InvoiceAddress = invoiceAddress;
        }
    }
}
