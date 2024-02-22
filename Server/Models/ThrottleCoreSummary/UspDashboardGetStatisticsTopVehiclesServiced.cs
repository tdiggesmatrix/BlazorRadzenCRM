using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    public partial class UspDashboardGetStatisticsTopVehiclesServiced
    {
        public int Placement { get; set; }
        [Column("Vehicle-Make")]
        public string VehicleMake { get; set; }
        [Column("Vehicle-Model")]
        public string VehicleModel { get; set; }

        public string Vehicle { get; set; }
        [Column("Number-Serviced")]
        public string NumberServiced { get; set; }

    }
}