using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagementDataAccessLayer.Model
{
    public partial class EmployeeDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
    }
}
