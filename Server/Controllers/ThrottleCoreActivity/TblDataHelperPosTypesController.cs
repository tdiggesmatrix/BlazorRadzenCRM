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
    [Route("odata/Throttle_Core_Activity/TblDataHelperPosTypes")]
    public partial class TblDataHelperPosTypesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataHelperPosTypesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> GetTblDataHelperPosTypes()
        {
            var items = this.context.TblDataHelperPosTypes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>();
            this.OnTblDataHelperPosTypesRead(ref items);

            return items;
        }

        partial void OnTblDataHelperPosTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> items);

        partial void OnTblDataHelperPosTypeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataHelperPosTypes(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> GetTblDataHelperPosType(int key)
        {
            var items = this.context.TblDataHelperPosTypes.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataHelperPosTypeGet(ref result);

            return result;
        }
        partial void OnTblDataHelperPosTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnAfterTblDataHelperPosTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataHelperPosTypes(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataHelperPosType(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataHelperPosTypes
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataHelperPosTypeDeleted(item);
                this.context.TblDataHelperPosTypes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataHelperPosTypeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperPosTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnAfterTblDataHelperPosTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataHelperPosTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataHelperPosType(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item)
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
                this.OnTblDataHelperPosTypeUpdated(item);
                this.context.TblDataHelperPosTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperPosTypes.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataHelperPosTypeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataHelperPosTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataHelperPosType(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataHelperPosTypes.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataHelperPosTypeUpdated(item);
                this.context.TblDataHelperPosTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperPosTypes.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperPosTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnAfterTblDataHelperPosTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item)
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

                this.OnTblDataHelperPosTypeCreated(item);
                this.context.TblDataHelperPosTypes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperPosTypes.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataHelperPosTypeCreated(item);

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
