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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Activity
{
    [Route("odata/Throttle_Core_Activity/TblMessageGroupingTypes")]
    public partial class TblMessageGroupingTypesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageGroupingTypesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> GetTblMessageGroupingTypes()
        {
            var items = this.context.TblMessageGroupingTypes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>();
            this.OnTblMessageGroupingTypesRead(ref items);

            return items;
        }

        partial void OnTblMessageGroupingTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> items);

        partial void OnTblMessageGroupingTypeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageGroupingTypes(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> GetTblMessageGroupingType(short key)
        {
            var items = this.context.TblMessageGroupingTypes.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageGroupingTypeGet(ref result);

            return result;
        }
        partial void OnTblMessageGroupingTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnAfterTblMessageGroupingTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageGroupingTypes(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageGroupingType(short key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageGroupingTypes
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageGroupingTypeDeleted(item);
                this.context.TblMessageGroupingTypes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageGroupingTypeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageGroupingTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnAfterTblMessageGroupingTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageGroupingTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageGroupingType(short key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item)
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
                this.OnTblMessageGroupingTypeUpdated(item);
                this.context.TblMessageGroupingTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageGroupingTypes.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageGroupingTypeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageGroupingTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageGroupingType(short key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageGroupingTypes.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageGroupingTypeUpdated(item);
                this.context.TblMessageGroupingTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageGroupingTypes.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageGroupingTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnAfterTblMessageGroupingTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item)
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

                this.OnTblMessageGroupingTypeCreated(item);
                this.context.TblMessageGroupingTypes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageGroupingTypes.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageGroupingTypeCreated(item);

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
