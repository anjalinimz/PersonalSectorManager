namespace PersonalSectorManager.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Sector? Parent { get; set; }
        public virtual ICollection<Sector> Children { get; set; }
        public List<UserSector> UserSectors { get; set; }

        public Sector(string name)
        {
            Name = name;
            Children = new List<Sector>();
            UserSectors = new List<UserSector>();
        }
    }
}

