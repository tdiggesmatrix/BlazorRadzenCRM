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
    [Route("odata/Throttle_Core_Activity/TblDataImportVerifications")]
    public partial class TblDataImportVerificationsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataImportVerificationsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> GetTblDataImportVerifications()
        {
            var items = this.context.TblDataImportVerifications.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>();
            this.OnTblDataImportVerificationsRead(ref items);

            return items;
        }

        partial void OnTblDataImportVerificationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> items);

        partial void OnTblDataImportVerificationGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataImportVerifications(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> GetTblDataImportVerification(int key)
        {
            var items = this.context.TblDataImportVerifications.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataImportVerificationGet(ref result);

            return result;
        }
        partial void OnTblDataImportVerificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnAfterTblDataImportVerificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataImportVerifications(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataImportVerification(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataImportVerifications
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataImportVerificationDeleted(item);
                this.context.TblDataImportVerifications.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataImportVerificationDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataImportVerificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnAfterTblDataImportVerificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataImportVerifications(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataImportVerification(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item)
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
                this.OnTblDataImportVerificationUpdated(item);
                this.context.TblDataImportVerifications.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataImportVerifications.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataImportVerificationUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataImportVerifications(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataImportVerification(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataImportVerifications.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataImportVerificationUpdated(item);
                this.context.TblDataImportVerifications.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataImportVerifications.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataImportVerificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnAfterTblDataImportVerificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item)
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

                this.OnTblDataImportVerificationCreated(item);
                this.context.TblDataImportVerifications.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataImportVerifications.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataImportVerificationCreated(item);

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
