using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.models
{
    public class Ant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeInDays { get; set; }
        public string FavoriteAntGame { get; set; }

        public virtual IList<AntHiveRelation> Hives { get; set; } = new List<AntHiveRelation>();

        public override string ToString()
        {
            return $"Ant {Id}: {Name} is {AgeInDays} days old and loves {FavoriteAntGame}.";
        }
    }
}
