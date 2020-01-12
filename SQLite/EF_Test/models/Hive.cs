using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.models
{
    public class Hive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Queen Queen { get; set; }
        public virtual IList<AntHiveRelation> Ants { get; set; } = new List<AntHiveRelation>();

        public override string ToString()
        {
            return $"Hive {Id}: {Name}";
        }
    }
}
