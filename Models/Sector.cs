using System;
namespace PersonalSectorManager.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public int? ParentId { get; set; }
        public virtual Sector? Parent { get; set; }
        public virtual ICollection<Sector>? Children { get; set; }

        public Sector(string name)
        {
            Name = name;
        }
    }
}

