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
    [Route("odata/Throttle_Core_Billing/SettingsContacts")]
    public partial class SettingsContactsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public SettingsContactsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> GetSettingsContacts()
        {
            var items = this.context.SettingsContacts.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>();
            this.OnSettingsContactsRead(ref items);

            return items;
        }

        partial void OnSettingsContactsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> items);

        partial void OnSettingsContactGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/SettingsContacts(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> GetSettingsContact(int key)
        {
            var items = this.context.SettingsContacts.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnSettingsContactGet(ref result);

            return result;
        }
        partial void OnSettingsContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnAfterSettingsContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);

        [HttpDelete("/odata/Throttle_Core_Billing/SettingsContacts(fldRecordID={fldRecordID})")]
        public IActionResult DeleteSettingsContact(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.SettingsContacts
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnSettingsContactDeleted(item);
                this.context.SettingsContacts.Remove(item);
                this.context.SaveChanges();
                this.OnAfterSettingsContactDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSettingsContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnAfterSettingsContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);

        [HttpPut("/odata/Throttle_Core_Billing/SettingsContacts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutSettingsContact(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item)
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
                this.OnSettingsContactUpdated(item);
                this.context.SettingsContacts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SettingsContacts.Where(i => i.fldRecordID == key);
                
                this.OnAfterSettingsContactUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/SettingsContacts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchSettingsContact(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.SettingsContacts.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnSettingsContactUpdated(item);
                this.context.SettingsContacts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SettingsContacts.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSettingsContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnAfterSettingsContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item)
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

                this.OnSettingsContactCreated(item);
                this.context.SettingsContacts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SettingsContacts.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterSettingsContactCreated(item);

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
