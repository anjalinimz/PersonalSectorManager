using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public interface ISectorService
	{
        List<SectorViewModel> RetrieveSectors();
    }
}

