using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public interface ISectorService
	{
        /* 
         * Retrieves all the sectors from the database and performs the following steps:
         *
         *  - Constructs the hierarchy of the sectors.
         *  - Calculates the level and determines the visibility of each sector based on the hierarchy.
         *  - Transforms sectors into SectorViewModels.
         *  
         *  Returns the list of SectorViewModels.
         */
        List<SectorViewModel> RetrieveHierarchicalSectors();
    }
}

