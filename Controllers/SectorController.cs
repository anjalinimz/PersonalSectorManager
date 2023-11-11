using System;
using Microsoft.AspNetCore.Mvc;

namespace PersonalSectorManager.Controllers
{
    public class SectorController : Controller
    {
        private readonly ILogger<SectorController> _logger;

        public SectorController(ILogger<SectorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //call and retrieve sectorList from SectorService
            //Return the list to View
            return View();
        }
    }
}

