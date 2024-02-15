using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("Employee", Schema = "dbo")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? DepartmentID { get; set; }

        public Department Department { get; set; }

        public int? ManagerID { get; set; }

        public int? Salary { get; set; }

        public decimal? Bonus { get; set; }

    }
}