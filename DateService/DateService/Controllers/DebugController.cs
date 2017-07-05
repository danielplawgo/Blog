using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateService.Services;
using DateService.ViewModels.Debug;

namespace DateService.Controllers
{
    public class DebugController : Controller
    {
        private Services.DateService _dateService;

        public DebugController(Services.DateService dateService)
        {
            _dateService = dateService;
        }

        public ActionResult Date()
        {
            var viewModel = new DateViewModel()
            {
                Now = _dateService.Now,
                NewDate = _dateService.Now
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Date(DateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dateService.SetNow(viewModel.NewDate);
            }

            viewModel.Now = _dateService.Now;

            return View(viewModel);
        }

        public ActionResult ResetDate()
        {
            _dateService.Reset();

            return RedirectToAction("Date");
        }

        public ActionResult _GetDate()
        {
            return Json(_dateService.Now.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}