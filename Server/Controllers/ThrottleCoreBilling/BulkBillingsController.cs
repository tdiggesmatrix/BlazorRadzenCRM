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
    [Route("odata/Throttle_Core_Billing/BulkBillings")]
    public partial class BulkBillingsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public BulkBillingsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> GetBulkBillings()
        {
            var items = this.context.BulkBillings.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>();
            this.OnBulkBillingsRead(ref items);

            return items;
        }

        partial void OnBulkBillingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> items);

        partial void OnBulkBillingGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/BulkBillings(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> GetBulkBilling(int key)
        {
            var items = this.context.BulkBillings.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnBulkBillingGet(ref result);

            return result;
        }
        partial void OnBulkBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnAfterBulkBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);

        [HttpDelete("/odata/Throttle_Core_Billing/BulkBillings(fldRecordID={fldRecordID})")]
        public IActionResult DeleteBulkBilling(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.BulkBillings
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnBulkBillingDeleted(item);
                this.context.BulkBillings.Remove(item);
                this.context.SaveChanges();
                this.OnAfterBulkBillingDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnBulkBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnAfterBulkBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);

        [HttpPut("/odata/Throttle_Core_Billing/BulkBillings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutBulkBilling(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item)
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
                this.OnBulkBillingUpdated(item);
                this.context.BulkBillings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.BulkBillings.Where(i => i.fldRecordID == key);
                
                this.OnAfterBulkBillingUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/BulkBillings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchBulkBilling(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.BulkBillings.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnBulkBillingUpdated(item);
                this.context.BulkBillings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.BulkBillings.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnBulkBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnAfterBulkBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item)
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

                this.OnBulkBillingCreated(item);
                this.context.BulkBillings.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.BulkBillings.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterBulkBillingCreated(item);

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
