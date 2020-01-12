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
        public virtual IList<Ant> Ants { get; set; } = new List<Ant>();

        public override string ToString()
        {
            return $"Hive {Id}: {Name}";
        }
    }
}
