﻿using Customer_Invoice_Payment_Management.Model.Common;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.DataLogic.Abstract
{
    public interface IInvoice
    {
        public List<Invoice> GetInvoice();
        public int AddInvoiceData(Invoice InvoiceModel, string InvoiceNo);
        public int UpdateInvoice(Invoice InvoiceModel, string InvoiceNo, string InvoiceName);
        public int DeleteInvoice(string InvoiceNo);
        public Invoice InvoiceById(string InvoiceNo);
        public List<Invoice> AutoIncrementInvoiceNo();
    }
}