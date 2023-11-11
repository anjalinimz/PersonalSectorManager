using System;
namespace PersonalSectorManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Sector Sector { get; set; }
        public int SectorId { get; set; } // Foreign key to Sector table
        public bool AgreeToTerms { get; set; }

        public User(string userName, int sectorId, bool agreeToTerms)
        {
            UserName = userName;
            SectorId = sectorId;
            AgreeToTerms = agreeToTerms;
        }
    }
}

