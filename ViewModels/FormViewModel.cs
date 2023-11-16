namespace PersonalSectorManager.ViewModels
{
    // Combining user data and the list of sector options.
    public class FormViewModel
	{
        public UserViewModel? UserViewModel { get; set; }
		public List<SectorViewModel>? SectorViewModels { get; set; }

    }
}

