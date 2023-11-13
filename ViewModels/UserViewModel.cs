using System.ComponentModel.DataAnnotations;

namespace PersonalSectorManager.ViewModels
{
    public class UserViewModel
	{
		public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, ErrorMessage = "Name cannot exceed 40 characters")]
        [RegularExpression("^[a-zA-Z' -]+$", ErrorMessage = "Invalid characters. Only letters, spaces, hyphens, and apostrophes are allowed.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "At least One sector should be selected")]
        public List<int>? SelectedSectorIds { get; set; }

        [Required(ErrorMessage = "You must agreed to our terms before proceeding")]
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
