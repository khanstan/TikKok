using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TikKok.Web.Controllers
{
    public class ProfileController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
