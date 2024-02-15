using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    public partial class SpGetGeocodeByAddressOrPlaceResult
    {
        public string APIkey { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string County { get; set; }

        public decimal? GPSLatitude { get; set; }

        public decimal? GPSLongitude { get; set; }

        public string MapURL { get; set; }

        public string PlaceID { get; set; }

        public int returnValue { get; set; }

    }
}