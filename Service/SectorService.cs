using System;
using Microsoft.EntityFrameworkCore;
using PersonalSectorManager.Models;

namespace PersonalSectorManager.Service
{
    public class SectorService
    {
        private readonly PersonalSectorDBContext _context;

        public SectorService(PersonalSectorDBContext context)
        {
            _context = context;
        }
    }
}

