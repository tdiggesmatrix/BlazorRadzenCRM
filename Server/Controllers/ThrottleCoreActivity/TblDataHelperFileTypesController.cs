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
    [Route("odata/Throttle_Core_Activity/TblDataHelperFileTypes")]
    public partial class TblDataHelperFileTypesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataHelperFileTypesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> GetTblDataHelperFileTypes()
        {
            var items = this.context.TblDataHelperFileTypes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>();
            this.OnTblDataHelperFileTypesRead(ref items);

            return items;
        }

        partial void OnTblDataHelperFileTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> items);

        partial void OnTblDataHelperFileTypeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataHelperFileTypes(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> GetTblDataHelperFileType(int key)
        {
            var items = this.context.TblDataHelperFileTypes.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataHelperFileTypeGet(ref result);

            return result;
        }
        partial void OnTblDataHelperFileTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnAfterTblDataHelperFileTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataHelperFileTypes(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataHelperFileType(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataHelperFileTypes
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataHelperFileTypeDeleted(item);
                this.context.TblDataHelperFileTypes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataHelperFileTypeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperFileTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnAfterTblDataHelperFileTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataHelperFileTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataHelperFileType(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item)
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
                this.OnTblDataHelperFileTypeUpdated(item);
                this.context.TblDataHelperFileTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperFileTypes.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataHelperFileTypeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataHelperFileTypes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataHelperFileType(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataHelperFileTypes.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataHelperFileTypeUpdated(item);
                this.context.TblDataHelperFileTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperFileTypes.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperFileTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnAfterTblDataHelperFileTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item)
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

                this.OnTblDataHelperFileTypeCreated(item);
                this.context.TblDataHelperFileTypes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperFileTypes.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataHelperFileTypeCreated(item);

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
