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
    [Route("odata/Throttle_Core_Activity/TblMessageNotifications")]
    public partial class TblMessageNotificationsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageNotificationsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> GetTblMessageNotifications()
        {
            var items = this.context.TblMessageNotifications.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>();
            this.OnTblMessageNotificationsRead(ref items);

            return items;
        }

        partial void OnTblMessageNotificationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> items);

        partial void OnTblMessageNotificationGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageNotifications(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> GetTblMessageNotification(int key)
        {
            var items = this.context.TblMessageNotifications.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageNotificationGet(ref result);

            return result;
        }
        partial void OnTblMessageNotificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnAfterTblMessageNotificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageNotifications(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageNotification(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageNotifications
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageNotificationDeleted(item);
                this.context.TblMessageNotifications.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageNotificationDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageNotificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnAfterTblMessageNotificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageNotifications(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageNotification(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item)
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
                this.OnTblMessageNotificationUpdated(item);
                this.context.TblMessageNotifications.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageNotifications.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageNotificationUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageNotifications(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageNotification(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageNotifications.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageNotificationUpdated(item);
                this.context.TblMessageNotifications.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageNotifications.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageNotificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnAfterTblMessageNotificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item)
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

                this.OnTblMessageNotificationCreated(item);
                this.context.TblMessageNotifications.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageNotifications.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageNotificationCreated(item);

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
