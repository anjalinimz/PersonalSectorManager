using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PersonalSectorManager.Models;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public class UserService : IUserService
    {
        private readonly ProfileDBContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(ProfileDBContext context, ILogger<UserService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int SaveUser(UserViewModel userViewModel)
        {
            try
            {
                ValidateUserViewModel(userViewModel);

                var user = new User(userViewModel.UserName ?? string.Empty)
                {
                    UserId = userViewModel.UserId,
                    AgreeToTerms = userViewModel.AgreeToTerms
                };

                if (userViewModel.UserId == 0)
                {
                    AddNewUser(user);
                }
                else
                {
                    UpdateExistingUser(user);
                    RemoveExistingSectors(user.UserId);
                }

                ValidateSelectedSectors(userViewModel);
                AddUserSectors(userViewModel, user);

                return user.UserId;
            }
            catch (DbException ex)
            {
                _logger.LogError($"Error occurred while performing DB operations: {ex.Message}");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"An unexpected error occurred: {e.Message}");
                throw;
            }
        }

        public UserViewModel GetUser(int userId)
        {
            var user = _context.Users.Include(u => u.UserSectors)
                .ThenInclude(us => us.Sector)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                _logger.LogError($"User with ID {userId} not found.");
                throw new ArgumentNullException(nameof(user));
            }

            var userViewModel = new UserViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                AgreeToTerms = user.AgreeToTerms,
                Sectors = user?.UserSectors?.Select(u => new SectorViewModel(u.Sector.SectorId, u.Sector.Name)).ToList()
            };


            return userViewModel;
        }

        private void AddUserSectors(UserViewModel userViewModel, User user)
        {
            var selectedSectors = _context.Sectors
                                .Where(s => userViewModel.SelectedSectorIds.Contains(s.SectorId)).ToList();

            foreach (var sector in selectedSectors)
            {
                _context.Entry(sector).State = EntityState.Unchanged;
                user.UserSectors.Add(new UserSector(user.UserId, sector.SectorId));
            }

            _context.SaveChanges();
        }

        private void ValidateSelectedSectors(UserViewModel userViewModel)
        {
            if (userViewModel.SelectedSectorIds == null || !userViewModel.SelectedSectorIds.Any())
            {
                string errorMessage = "At least one sector should be selected.";
                _logger.LogError($"{nameof(userViewModel.SelectedSectorIds)} validation failed: {errorMessage}");
                throw new ArgumentNullException(nameof(userViewModel.SelectedSectorIds), errorMessage);
            }
        }

        private void RemoveExistingSectors(int userId)
        {
            var existingSectors = _context.UserSectors.Where(us => us.UserId == userId);
            _context.UserSectors.RemoveRange(existingSectors);
        }

        private void UpdateExistingUser(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        private void AddNewUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private void ValidateUserViewModel(UserViewModel userViewModel)
        {
            if (userViewModel == null)
            {
                _logger.LogError($"{nameof(userViewModel)} should not be null");
                throw new ArgumentNullException(nameof(userViewModel));
            }
        }
    }
}

 