using System.Data.Common;
using PersonalSectorManager.Models;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public class SectorService : ISectorService
    {
        private readonly ProfileDBContext _context;
        private readonly ILogger<SectorService> _logger;

        public SectorService(ProfileDBContext context, ILogger<SectorService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<SectorViewModel> RetrieveHierarchicalSectors()
        {
            try
            {
                var sectorViewModels = new List<SectorViewModel>();

                var sectors = _context.Sectors.ToList();
                var hierarchicalSectors = BuildHierarchicalList(sectors);

                return hierarchicalSectors;

            }
            catch (DbException ex)
            {
                _logger.LogError($"Error occurred while performing DB operations: {ex.Message}");
                throw;
            }
        }

        private List<SectorViewModel> BuildHierarchicalList(List<Sector> sectors)
        {
            var hierarchy = new Dictionary<int, List<Sector>>();

            foreach (var sector in sectors)
            {
                if (!hierarchy.ContainsKey(sector.ParentId ?? 0))
                {
                    hierarchy.Add(sector.ParentId ?? 0, new List<Sector>());
                }

                hierarchy[sector.ParentId ?? 0].Add(sector);
            }

            var hierarchicalList = new List<SectorViewModel>();
            AddSectorsToList(hierarchy[0], hierarchicalList, hierarchy, 0);

            return hierarchicalList;
        }

        private void AddSectorsToList(List<Sector> sectors, List<SectorViewModel> hierarchicalList,
            Dictionary<int, List<Sector>> hierarchy, int level)
        {
            foreach (var sector in sectors)
            {
                var sectorViewModel = new SectorViewModel(sector.SectorId, sector.Name)
                {
                    Level = level,
                    Disabled = hierarchy.ContainsKey(sector.SectorId)
                };

                hierarchicalList.Add(sectorViewModel);

                if (hierarchy.ContainsKey(sector.SectorId))
                {
                    AddSectorsToList(hierarchy[sector.SectorId], hierarchicalList, hierarchy, level + 1);
                }
            }
        }
    }
}

