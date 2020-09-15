using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Interfaces.Api;

namespace WebStoreGusev.Controllers
{
    public class WebAPITestController : Controller
    {
        private readonly IValueServices valueServices;

        public WebAPITestController(IValueServices valueServices)
        {
            this.valueServices = valueServices;
        }

        public IActionResult Index() => View(valueServices.Get());
        
    }
}
