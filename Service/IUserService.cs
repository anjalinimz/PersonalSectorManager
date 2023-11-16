using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public interface IUserService
	{
        // Saves a user to the database based on the provided UserViewModel.
        int SaveUser(UserViewModel userDTO);

        // Retrieves the user based on the provided user ID and transform it to UserViewModel.
        UserViewModel GetUser(int userId);
    }
}

