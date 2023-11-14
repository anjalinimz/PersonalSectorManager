using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using PersonalSectorManager.Service;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly ISectorService _sectorService;

        public UserController(ILogger<UserController> logger, IUserService userService, ISectorService sectorService)
		{
            _logger = logger;
            _userService = userService;
            _sectorService = sectorService;

        }

        public IActionResult Index(UserViewModel userViewModel)
        {
            try
            {
                var sectorViewModels = _sectorService.RetrieveSectors();

                FormViewModel formViewModel = new()
                {
                    SectorViewModels = sectorViewModels,
                    UserViewModel = userViewModel
                };

                return View(formViewModel);
            }
            catch (DbException dbException)
            {
                _logger.LogError(dbException, "Database error occurred while retrieving sectors.");
                return View("Error", "Database error occurred while retrieving sectors. " + dbException.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(FormViewModel formViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int userId = _userService.SaveUser(formViewModel.UserViewModel);
                    return RedirectToAction("Confirmation", new { userId });
                }
                else
                {
                    formViewModel.SectorViewModels = _sectorService.RetrieveSectors();
                    return View("Index", formViewModel);
                }
            }
            catch (DbException dbException)
            {
                _logger.LogError(dbException, "Database error occurred. ");
                return View("Error", "Database error occurred. <br/>" + dbException.Message);
            }
            catch (ArgumentNullException argEx)
            {
                _logger.LogError(argEx, "Argument error occurred. ");
                return View("Error", "An argument error occurred while saving user. " + argEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while saving user.");
                return View("Error", "An unexpected error occurred while saving user. " + ex.Message);
            }
        }

        public IActionResult Confirmation(int userId)
        {
            try
            {
                UserViewModel user = _userService.GetUser(userId);

                return View(user);
            }
            catch (DbException dbException)
            {
                _logger.LogError(dbException, "Database error occurred while saving user.");
                return View("Error", "Database error occurred while saving user. " + dbException.Message);
            }
        }
    }
}

  