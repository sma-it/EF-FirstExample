using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.models
{
    public class Queen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeInDays { get; set; }

        public override string ToString()
        {
            return $"Queen {Id}: {Name} is {AgeInDays} days old.";
        }

    }
}
