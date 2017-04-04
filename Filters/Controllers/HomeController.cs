using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    //[Profile]
    //[ViewResultDetails]
    //[RangeException]
    [TypeFilter(typeof(DiagnosticsFilter))]
    [ServiceFilter(typeof(TimeFilter))]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Message",
                "This is the Index action on the Home Controller");
            
        }
        
        public ViewResult SecondAction() => View("Message",
            "This is the SecondAction action on the Home controller");

        public ViewResult GenerateException(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            } else if(id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            } else
            {
                return View("Message", $"The value is {id}");
            }
        }
    }
}
