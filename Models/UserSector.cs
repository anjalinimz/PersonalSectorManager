namespace PersonalSectorManager.Models
{
    public class UserSector
	{
        public int UserSectorId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }

        public UserSector(int userId, int sectorId)
        {
            UserId = userId;
            SectorId = sectorId;
        }
    }
}

