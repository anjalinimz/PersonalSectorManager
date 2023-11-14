using PersonalSectorManager.Models;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Util
{
    public interface ITransformer
	{
        UserViewModel TransformToUserViewModel(User user);

        User TransformToUser(UserViewModel userViewModel);

        SectorViewModel TransformToSectorViewModel(Sector sector);

    }
}

