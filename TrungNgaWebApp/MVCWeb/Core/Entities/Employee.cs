using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeType { get; set; }

        public virtual ICollection<Transport> TransportsForDriver { get; set; }
        public virtual ICollection<Transport> TransportsForAssistant { get; set; }

    }
}