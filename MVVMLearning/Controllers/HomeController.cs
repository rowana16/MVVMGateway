using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVVMLearningData;

namespace MVVMLearning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TrainingProductViewModel vm = new TrainingProductViewModel();            
            vm.HandleRequest();

            return View(vm);
        }

        
    }
}