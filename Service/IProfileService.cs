using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public interface IProfileService
    {
        FormViewModel RetrieveSectors();

        int SaveUser(UserViewModel userDTO);

        UserViewModel GetUser(int userId);
    }
}

