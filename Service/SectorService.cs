using Microsoft.EntityFrameworkCore;
using PersonalSectorManager.Models;
using PersonalSectorManager.Util;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public class SectorService : IProfileService
    {
        private readonly ProfileDBContext _context;
        private readonly ITransformer _transformer;

        public SectorService(ProfileDBContext context, ITransformer transformer)
        {
            _context = context;
            _transformer = transformer;
        }

        public FormViewModel RetrieveSectors()
        {
            var sectorViewModels = new List<SectorViewModel>();

            var sectors = _context.Sectors.ToList();

            foreach (var sector in sectors)
            {
                SectorViewModel  sectorViewModel = _transformer.TransformToSectorViewModel(sector);
                sectorViewModel.Level = getItemLevel(sector);

                sectorViewModels.Add(sectorViewModel);
            }

            FormViewModel formViewModel = new()
            {
                SectorViewModels = sectorViewModels
            };

            return formViewModel;
        }

        public int SaveUser(UserViewModel userViewModel)
        {
            User user = _transformer.TransformToUser(userViewModel);

            var selectedSectors = _context.Sectors
               .Where(s => userViewModel.SelectedSectorIds.Contains(s.SectorId)).ToList();  // todo handle null

            // Assuming the user is a new user, you may need to attach it to the context.
            // If the user is an existing user, you might not need to attach.
            if (userViewModel.UserId == 0)
            {
                _context.Users.Add(user);

                // Save changes to generate the User's ID
                _context.SaveChanges();
            }
            else
            {
                _context.Users.Attach(user);
                _context.Entry(user).State = EntityState.Modified;

                // Remove existing UserSectors
                var existingSectors = _context.UserSectors.Where(us => us.UserId == user.UserId);
                _context.UserSectors.RemoveRange(existingSectors);
            }

            // Attach and add new UserSectors
            foreach (var sector in selectedSectors)
            {
                _context.Entry(sector).State = EntityState.Unchanged;
                user.UserSectors.Add(new UserSector(user.UserId, sector.SectorId));
            }
            _context.SaveChanges();

            return user.UserId;
        }

        public UserViewModel GetUser(int userId)
        {

            var user = _context.Users.Include(u => u.UserSectors)
                .ThenInclude(us => us.Sector)
                .FirstOrDefault(u => u.UserId == userId);

            UserViewModel userViewModel = _transformer.TransformToUserViewModel(user);
            // todo handle null/ errors

            return userViewModel;
        }

        private int getItemLevel(Sector sector)
        {
            if (sector.ParentId == null)
            {
                return 1;
            } else
            {
                return getItemLevel(sector.Parent) + 1;  // todo Do we need to handle null here. 
            }
        }
    }
}

