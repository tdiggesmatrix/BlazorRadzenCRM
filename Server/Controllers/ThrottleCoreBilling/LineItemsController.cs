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
    [Route("odata/Throttle_Core_Billing/LineItems")]
    public partial class LineItemsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public LineItemsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> GetLineItems()
        {
            var items = this.context.LineItems.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>();
            this.OnLineItemsRead(ref items);

            return items;
        }

        partial void OnLineItemsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> items);

        partial void OnLineItemGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/LineItems(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> GetLineItem(int key)
        {
            var items = this.context.LineItems.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnLineItemGet(ref result);

            return result;
        }
        partial void OnLineItemDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnAfterLineItemDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);

        [HttpDelete("/odata/Throttle_Core_Billing/LineItems(fldRecordID={fldRecordID})")]
        public IActionResult DeleteLineItem(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.LineItems
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnLineItemDeleted(item);
                this.context.LineItems.Remove(item);
                this.context.SaveChanges();
                this.OnAfterLineItemDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnLineItemUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnAfterLineItemUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);

        [HttpPut("/odata/Throttle_Core_Billing/LineItems(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutLineItem(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item)
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
                this.OnLineItemUpdated(item);
                this.context.LineItems.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.LineItems.Where(i => i.fldRecordID == key);
                
                this.OnAfterLineItemUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/LineItems(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchLineItem(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.LineItems.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnLineItemUpdated(item);
                this.context.LineItems.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.LineItems.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnLineItemCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnAfterLineItemCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item)
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

                this.OnLineItemCreated(item);
                this.context.LineItems.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.LineItems.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterLineItemCreated(item);

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
