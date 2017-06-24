using LogicAuthorizeFilter.Filters;
using LogicAuthorizeFilter.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicAuthorizeFilter.Models;

namespace LogicAuthorizeFilter.Controllers
{
    [LogicAuthorize(typeof(IInvoiceLogic))]
    public class InvoicesController : Controller
    {
        private IInvoiceLogic _invoiceLogic;

        public InvoicesController(IInvoiceLogic invoiceLogic)
        {
            _invoiceLogic = invoiceLogic;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_invoiceLogic.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            return View(invoice);
        }
    }
}