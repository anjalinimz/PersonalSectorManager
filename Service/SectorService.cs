using System.Data.Common;
using PersonalSectorManager.Models;
using PersonalSectorManager.Util;
using PersonalSectorManager.ViewModels;

namespace PersonalSectorManager.Service
{
    public class SectorService : ISectorService
    {
        private readonly ProfileDBContext _context;
        private readonly ITransformer _transformer;

        public SectorService(ProfileDBContext context, ITransformer transformer)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _transformer = transformer ?? throw new ArgumentNullException(nameof(transformer));
        }

        public List<SectorViewModel> RetrieveSectors()
        {
            try
            {
                var sectorViewModels = new List<SectorViewModel>();

                var sectors = _context.Sectors.ToList();
                var hierarchicalSectors = BuildHierarchicalList(sectors);

                foreach (var sector in hierarchicalSectors)
                {
                    SectorViewModel sectorViewModel = _transformer.TransformToSectorViewModel(sector);

                    sectorViewModels.Add(sectorViewModel);
                }

                return sectorViewModels;

            } catch (DbException)
            {
                throw;
            }
        }

        private List<Sector> BuildHierarchicalList(List<Sector> sectors)
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

            var hierarchicalList = new List<Sector>();
            AddSectorsToList(hierarchy[0], hierarchicalList, hierarchy);

            return hierarchicalList;
        }

        private void AddSectorsToList(List<Sector> sectors, List<Sector> hierarchicalList, Dictionary<int, List<Sector>> hierarchy)
        {
            foreach (var sector in sectors)
            {
                hierarchicalList.Add(sector);

                if (hierarchy.ContainsKey(sector.SectorId))
                {
                    AddSectorsToList(hierarchy[sector.SectorId], hierarchicalList, hierarchy);
                }
            }
        }
    }
}

