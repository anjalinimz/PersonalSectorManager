namespace PersonalSectorManager.ViewModels
{
    // Providing information for sector options.
    public class SectorViewModel
	{
        public int Value { get; set; }
        public string Name { get; set; }
        public int Level { get; internal set; }
		public bool Disabled { get; set; }

        public SectorViewModel(int value, string name)
		{
			Value = value;
			Name = name;
		}
	}
}

