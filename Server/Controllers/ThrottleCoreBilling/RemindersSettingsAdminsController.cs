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
    [Route("odata/Throttle_Core_Billing/RemindersSettingsAdmins")]
    public partial class RemindersSettingsAdminsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public RemindersSettingsAdminsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> GetRemindersSettingsAdmins()
        {
            var items = this.context.RemindersSettingsAdmins.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>();
            this.OnRemindersSettingsAdminsRead(ref items);

            return items;
        }

        partial void OnRemindersSettingsAdminsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> items);

        partial void OnRemindersSettingsAdminGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/RemindersSettingsAdmins(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> GetRemindersSettingsAdmin(int key)
        {
            var items = this.context.RemindersSettingsAdmins.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnRemindersSettingsAdminGet(ref result);

            return result;
        }
        partial void OnRemindersSettingsAdminDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnAfterRemindersSettingsAdminDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);

        [HttpDelete("/odata/Throttle_Core_Billing/RemindersSettingsAdmins(fldRecordID={fldRecordID})")]
        public IActionResult DeleteRemindersSettingsAdmin(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.RemindersSettingsAdmins
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnRemindersSettingsAdminDeleted(item);
                this.context.RemindersSettingsAdmins.Remove(item);
                this.context.SaveChanges();
                this.OnAfterRemindersSettingsAdminDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnRemindersSettingsAdminUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnAfterRemindersSettingsAdminUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);

        [HttpPut("/odata/Throttle_Core_Billing/RemindersSettingsAdmins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutRemindersSettingsAdmin(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item)
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
                this.OnRemindersSettingsAdminUpdated(item);
                this.context.RemindersSettingsAdmins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.RemindersSettingsAdmins.Where(i => i.fldRecordID == key);
                
                this.OnAfterRemindersSettingsAdminUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/RemindersSettingsAdmins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchRemindersSettingsAdmin(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.RemindersSettingsAdmins.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnRemindersSettingsAdminUpdated(item);
                this.context.RemindersSettingsAdmins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.RemindersSettingsAdmins.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnRemindersSettingsAdminCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnAfterRemindersSettingsAdminCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item)
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

                this.OnRemindersSettingsAdminCreated(item);
                this.context.RemindersSettingsAdmins.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.RemindersSettingsAdmins.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterRemindersSettingsAdminCreated(item);

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
