using System;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime? JoinDate { get; set; }

        public int? SupervisorId { get; set; }

        public string SupervisorName { get; set; }
    }
}
