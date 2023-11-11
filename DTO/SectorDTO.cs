using System;
namespace PersonalSectorManager.DTO
{
    public class SectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public int Level { get; set; }

        public SectorDTO(string name)
        {
            Name = name;
        }
    }
}

