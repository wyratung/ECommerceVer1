﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        //This controller help auto redirect to swagger
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
