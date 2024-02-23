using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrottleCoreCRM.Shared.Models
{
    public class GetuspDashboardGetValuesSales_Result
    {

        // Step 4 (Get)
        [Column("Result Type")]
        [Required]
        public required String ResultType { get; set; }
    }
}
