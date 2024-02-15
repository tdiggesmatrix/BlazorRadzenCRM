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
    [Route("odata/Throttle_Core_Activity/TblDataHelperAcknowledgementTypes")]
    public partial class TblDataHelperAcknowledgementTypesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataHelperAcknowledgementTypesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> GetTblDataHelperAcknowledgementTypes()
        {
            var items = this.context.TblDataHelperAcknowledgementTypes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>();
            this.OnTblDataHelperAcknowledgementTypesRead(ref items);

            return items;
        }

        partial void OnTblDataHelperAcknowledgementTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> items);

        partial void OnTblDataHelperAcknowledgementTypeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataHelperAcknowledgementTypes(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> GetTblDataHelperAcknowledgementType(int key)
        {
            var items = this.context.TblDataHelperAcknowledgementTypes.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataHelperAcknowledgementTypeGet(ref result);

            return result;
        }
        partial void OnTblDataHelperAcknowledgementTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnAfterTblDataHelperAcknowledgementTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataHelperAcknowledgementTypes(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataHelperAcknowledgementType(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataHelperAcknowledgementTypes
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataHelperAcknowledgementTypeDeleted(item);
                this.context.TblDataHelperAcknowledgementTypes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataHelperAcknowledgementTypeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperAcknowledgementTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnAfterTblDataHelperAcknowledgementTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataHelperAcknowledgementTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataHelperAcknowledgementType(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item)
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
                this.OnTblDataHelperAcknowledgementTypeUpdated(item);
                this.context.TblDataHelperAcknowledgementTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperAcknowledgementTypes.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataHelperAcknowledgementTypeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataHelperAcknowledgementTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataHelperAcknowledgementType(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataHelperAcknowledgementTypes.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataHelperAcknowledgementTypeUpdated(item);
                this.context.TblDataHelperAcknowledgementTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperAcknowledgementTypes.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperAcknowledgementTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnAfterTblDataHelperAcknowledgementTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item)
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

                this.OnTblDataHelperAcknowledgementTypeCreated(item);
                this.context.TblDataHelperAcknowledgementTypes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperAcknowledgementTypes.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataHelperAcknowledgementTypeCreated(item);

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
