using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Billing
{
    public partial class SpGetGeocodeByAddressOrPlacesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public SpGetGeocodeByAddressOrPlacesController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Billing/SpGetGeocodeByAddressOrPlacesFunc(APIkey={APIkey},Address={Address},City={City},State={State},Country={Country},PostalCode={PostalCode},County={County},GPSLatitude={GPSLatitude},GPSLongitude={GPSLongitude},MapURL={MapURL},PlaceID={PlaceID})")]
        public IActionResult SpGetGeocodeByAddressOrPlacesFunc([FromODataUri] string APIkey, [FromODataUri] string Address, [FromODataUri] string City, [FromODataUri] string State, [FromODataUri] string Country, [FromODataUri] string PostalCode, [FromODataUri] string County, [FromODataUri] decimal? GPSLatitude, [FromODataUri] decimal? GPSLongitude, [FromODataUri] string MapURL, [FromODataUri] string PlaceID)
        {
            this.OnSpGetGeocodeByAddressOrPlacesDefaultParams(ref APIkey, ref Address, ref City, ref State, ref Country, ref PostalCode, ref County, ref GPSLatitude, ref GPSLongitude, ref MapURL, ref PlaceID);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@APIkey", SqlDbType.VarChar, 100) {Direction = ParameterDirection.InputOutput, Value = APIkey},
              new SqlParameter("@Address", SqlDbType.VarChar, 80) {Direction = ParameterDirection.InputOutput, Value = Address},
              new SqlParameter("@City", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = City},
              new SqlParameter("@State", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = State},
              new SqlParameter("@Country", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = Country},
              new SqlParameter("@PostalCode", SqlDbType.VarChar, 20) {Direction = ParameterDirection.InputOutput, Value = PostalCode},
              new SqlParameter("@County", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = County},
              new SqlParameter("@GPSLatitude", SqlDbType.Decimal, -1) {Direction = ParameterDirection.InputOutput, Value = GPSLatitude},
              new SqlParameter("@GPSLongitude", SqlDbType.Decimal, -1) {Direction = ParameterDirection.InputOutput, Value = GPSLongitude},
              new SqlParameter("@MapURL", SqlDbType.VarChar, 1024) {Direction = ParameterDirection.InputOutput, Value = MapURL},
              new SqlParameter("@PlaceID", SqlDbType.VarChar, 250) {Direction = ParameterDirection.InputOutput, Value = PlaceID},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_Get_Geocode_by_Address_or_Place] @APIkey out, @Address out, @City out, @State out, @Country out, @PostalCode out, @County out, @GPSLatitude out, @GPSLongitude out, @MapURL out, @PlaceID out", @params);

            var result = new ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult();

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Output || _p.Direction == ParameterDirection.InputOutput) && _p.Value == DBNull.Value)
                {
                    _p.Value = null;
                }
            }
                
            result.returnValue = Convert.ToInt32(@params[0].Value);
          result.APIkey = Convert.ToString(@params[1].Value);
          result.Address = Convert.ToString(@params[2].Value);
          result.City = Convert.ToString(@params[3].Value);
          result.State = Convert.ToString(@params[4].Value);
          result.Country = Convert.ToString(@params[5].Value);
          result.PostalCode = Convert.ToString(@params[6].Value);
          result.County = Convert.ToString(@params[7].Value);
          result.GPSLatitude = Convert.ToDecimal(@params[8].Value);
          result.GPSLongitude = Convert.ToDecimal(@params[9].Value);
          result.MapURL = Convert.ToString(@params[10].Value);
          result.PlaceID = Convert.ToString(@params[11].Value);

            this.OnSpGetGeocodeByAddressOrPlacesInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpGetGeocodeByAddressOrPlacesDefaultParams(ref string APIkey, ref string Address, ref string City, ref string State, ref string Country, ref string PostalCode, ref string County, ref decimal? GPSLatitude, ref decimal? GPSLongitude, ref string MapURL, ref string PlaceID);
      partial void OnSpGetGeocodeByAddressOrPlacesInvoke(ref ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult result);
    }
}
