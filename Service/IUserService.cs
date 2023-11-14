using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public interface IUserService
	{
        int SaveUser(UserViewModel userDTO);

        UserViewModel GetUser(int userId);
    }
}

