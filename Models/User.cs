namespace PersonalSectorManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool AgreeToTerms { get; set; }
        public List<UserSector> UserSectors { get; set; }

        public User(string userName)
        {
            UserName = userName;
            UserSectors = new List<UserSector>();
        }
    }
}

