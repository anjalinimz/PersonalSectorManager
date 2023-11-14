using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PersonalSectorManager.Models;
using PersonalSectorManager.Util;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public class UserService : IUserService
    {
        private readonly ProfileDBContext _context;
        private readonly ITransformer _transformer;

        public UserService(ProfileDBContext context, ITransformer transformer, ILogger<UserService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _transformer = transformer ?? throw new ArgumentNullException(nameof(transformer));
        }

        public int SaveUser(UserViewModel userViewModel)
        {
            try
            {
                ValidateUserViewModel(userViewModel);

                User user = _transformer.TransformToUser(userViewModel);

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
            catch (DbException)
            {
                throw;
            }
            catch (Exception)
            {
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
                throw new ArgumentNullException(nameof(user));
            }

            UserViewModel userViewModel = _transformer.TransformToUserViewModel(user);

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

        private static void ValidateSelectedSectors(UserViewModel userViewModel)
        {
            if (userViewModel.SelectedSectorIds == null || !userViewModel.SelectedSectorIds.Any())
            {
                throw new ArgumentNullException(nameof(userViewModel.SelectedSectorIds),
                    "At least one sector should be selected.");
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

        private static void ValidateUserViewModel(UserViewModel userViewModel)
        {
            if (userViewModel == null)
            {
                throw new ArgumentNullException(nameof(userViewModel));
            }
        }
    }
}

 