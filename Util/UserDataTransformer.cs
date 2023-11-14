using PersonalSectorManager.Models;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Util
{
    public class UserDataTransformer : ITransformer
	{
		public UserDataTransformer()
		{
		}

		public UserViewModel TransformToUserViewModel(User user)
		{

            UserViewModel userViewModel = new()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                AgreeToTerms = user.AgreeToTerms,
                Sectors = user?.UserSectors?.Select(u => TransformToSectorViewModel(u.Sector)).ToList()
            };

            return userViewModel;
		}

        public User TransformToUser(UserViewModel userViewModel)
        {
            var user = new User(userViewModel.UserName ?? string.Empty)
            {
                UserId = userViewModel.UserId,
                AgreeToTerms = userViewModel.AgreeToTerms
            };

            return user;
        }

        public SectorViewModel TransformToSectorViewModel(Sector sector)
        {
            SectorViewModel sectorViewModel = new(sector.SectorId, sector.Name)
            {
                Level =  GetItemLevel(sector),
                Disabled = sector.Children.Any()
            };

            return sectorViewModel;
        }

        private int GetItemLevel(Sector sector)
        {
            if (sector == null)
            {
                return 0;
            }
            else if (sector.ParentId == null)
            {
                return 0;
            }
            else
            {
                return GetItemLevel(sector.Parent) + 1;
            }
        }
    }
}

