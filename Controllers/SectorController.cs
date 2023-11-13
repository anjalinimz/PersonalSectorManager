using Microsoft.AspNetCore.Mvc;
using PersonalSectorManager.Service;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Controllers
{
    public class SectorController : Controller
    {
        private readonly ILogger<SectorController> _logger; // todo use this logger appropriately
        private readonly IProfileService _sectorService;

        public SectorController(ILogger<SectorController> logger, IProfileService sectorService)
        {
            _logger = logger;
            _sectorService = sectorService;
        }

        public IActionResult Index(UserViewModel userViewModel)
        {
            var formView = _sectorService.RetrieveSectors();

            if (userViewModel != null)
            {
                formView.UserViewModel = userViewModel;
            }

            return View(formView);
        }

        [HttpPost]
        public IActionResult Create(FormViewModel formViewModel)
        {

            if (ModelState.IsValid)
            {
                int userId = _sectorService.SaveUser(formViewModel.UserViewModel);
                return RedirectToAction("Confirmation", new { userId });
            }

            return View("Error");
        }

        public IActionResult Confirmation(int userId)
        {
            UserViewModel user = _sectorService.GetUser(userId);

            if (user != null)
            {
                return View(user);
            }

            // Handle the case where the user with the given ID is not found
            return View("Error");
        }
    }
}

