using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("userdetails", Schema = "dbo")]
    public partial class Userdetail
    {
        [Required]
        public int userid { get; set; }

        public string username { get; set; }

        public string address { get; set; }

        public string cellnumber { get; set; }

        public string emailid { get; set; }

    }
}