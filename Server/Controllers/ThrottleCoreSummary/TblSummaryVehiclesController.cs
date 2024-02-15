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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Summary
{
    [Route("odata/Throttle_Core_Summary/TblSummaryVehicles")]
    public partial class TblSummaryVehiclesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblSummaryVehiclesController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> GetTblSummaryVehicles()
        {
            var items = this.context.TblSummaryVehicles.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>();
            this.OnTblSummaryVehiclesRead(ref items);

            return items;
        }

        partial void OnTblSummaryVehiclesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> items);

        partial void OnTblSummaryVehicleGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblSummaryVehicles(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> GetTblSummaryVehicle(int key)
        {
            var items = this.context.TblSummaryVehicles.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblSummaryVehicleGet(ref result);

            return result;
        }
        partial void OnTblSummaryVehicleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnAfterTblSummaryVehicleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblSummaryVehicles(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblSummaryVehicle(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblSummaryVehicles
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblSummaryVehicleDeleted(item);
                this.context.TblSummaryVehicles.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblSummaryVehicleDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummaryVehicleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnAfterTblSummaryVehicleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);

        [HttpPut("/odata/Throttle_Core_Summary/TblSummaryVehicles(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblSummaryVehicle(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.fldRecordID != key))
                {
                    return BadRequest();
                }
                this.OnTblSummaryVehicleUpdated(item);
                this.context.TblSummaryVehicles.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryVehicles.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblSummaryVehicleUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblSummaryVehicles(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblSummaryVehicle(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblSummaryVehicles.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblSummaryVehicleUpdated(item);
                this.context.TblSummaryVehicles.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryVehicles.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummaryVehicleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnAfterTblSummaryVehicleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnTblSummaryVehicleCreated(item);
                this.context.TblSummaryVehicles.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryVehicles.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblSummaryVehicleCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
