using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrottleCoreCRM.Shared.Models
{
    public class GetEmployeesWithDepartment_Result
    {

        // Step 4 (Get)
        public int Id { 
            get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public int Salary { get; set; }
        public decimal Bonus { get; set; }
        public string Department { get; set; }
    }
}
