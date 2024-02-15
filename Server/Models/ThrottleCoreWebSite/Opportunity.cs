using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("Opportunities", Schema = "dbo")]
    public partial class Opportunity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        [Required]
        public int StatusId { get; set; }

        public OpportunityStatus OpportunityStatus { get; set; }

        [Required]
        public DateTime CloseDate { get; set; }

        public ICollection<Task> Tasks { get; set; }

    }
}