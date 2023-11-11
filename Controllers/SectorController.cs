using System;
using Microsoft.AspNetCore.Mvc;
using PersonalSectorManager.Service;

namespace PersonalSectorManager.Controllers
{
    public class SectorController : Controller
    {
        private readonly ILogger<SectorController> _logger;
        private IProfileService _sectorService;

        public SectorController(ILogger<SectorController> logger, IProfileService sectorService)
        {
            _logger = logger;
            _sectorService = sectorService;
        }

        public IActionResult Index()
        {
            //call and retrieve sectorList from SectorService
            //Return the list to View
            var sectorList = _sectorService.retrieveSectors();

            return View(sectorList);
        }
    }
}

