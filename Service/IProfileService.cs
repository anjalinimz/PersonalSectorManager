using System;
using PersonalSectorManager.DTO;

namespace PersonalSectorManager.Service
{
    public interface IProfileService
    {
        List<SectorDTO> retrieveSectors();
    }
}

