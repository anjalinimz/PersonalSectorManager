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

        public SectorService(ProfileDBContext context, ITransformer transformer, ILogger<SectorService> logger)
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

                foreach (var sector in sectors)
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
    }
}

