namespace PersonalSectorManager.ViewModels
{
    public class UserViewModel
	{
		public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<int>? SelectedSectorIds { get; set; }
        public bool AgreeToTerms { get; set; }
		public List<SectorViewModel>? Sectors { get; set; }


        public UserViewModel()
        {
            UserName = "";
            SelectedSectorIds = new List<int>();
            Sectors = new List<SectorViewModel>();
        }

    }
}
