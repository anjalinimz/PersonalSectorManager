using System;
using Microsoft.EntityFrameworkCore;
using PersonalSectorManager.DTO;
using PersonalSectorManager.Models;

namespace PersonalSectorManager.Service
{
    public class SectorService : IProfileService
    {
        private readonly PersonalSectorDBContext _context;

        public SectorService(PersonalSectorDBContext context)
        {
            _context = context;
        }

        public List<SectorDTO> retrieveSectors()
        {
            var sectorDTOs = new List<SectorDTO>();

            var sectors = _context.Sectors.ToList();

            foreach (var sector in sectors)
            {
                SectorDTO sectorDTO = new SectorDTO(sector.Name);
                sectorDTO.Id = sector.Id;
                sectorDTO.OrderIndex = sector.OrderIndex;
                sectorDTO.Level = getItemLevel(sector);

                sectorDTOs.Add(sectorDTO);
            }

            return sectorDTOs;
        }

        private int getItemLevel(Sector sector)
        {
            if (sector.ParentId == null)
            {
                return 1;
            } else
            {
                return getItemLevel(sector.Parent) + 1;
            }
        }
    }
}

