using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.models
{
    public class AntHiveRelation
    {
        public AntHiveRelation() { }

        public AntHiveRelation(Ant ant, Hive hive)
        {
            this.Ant = ant;
            this.Hive = hive;
        }

        public int AntId { get; set; }
        public virtual Ant Ant { get; set; }

        public int HiveId { get; set; }
        public virtual Hive Hive { get; set; }
    }
}
