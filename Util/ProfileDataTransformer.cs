﻿using PersonalSectorManager.Models;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Util
{
    public class ProfileDataTransformer : ITransformer
	{
		public ProfileDataTransformer()
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
            var user = new User(userViewModel.UserName)
            {
                UserId = userViewModel.UserId,
                AgreeToTerms = userViewModel.AgreeToTerms
            };

            return user;
        }

        public SectorViewModel TransformToSectorViewModel(Sector sector)
        {
            SectorViewModel sectorViewModel = new(sector.SectorId, sector.Name);
            return sectorViewModel;
        }
    }
}
