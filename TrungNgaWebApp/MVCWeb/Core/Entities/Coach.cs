using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }

    }
}