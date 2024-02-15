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
    [Route("odata/Throttle_Core_Billing/CustomerShippings")]
    public partial class CustomerShippingsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public CustomerShippingsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> GetCustomerShippings()
        {
            var items = this.context.CustomerShippings.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>();
            this.OnCustomerShippingsRead(ref items);

            return items;
        }

        partial void OnCustomerShippingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> items);

        partial void OnCustomerShippingGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/CustomerShippings(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> GetCustomerShipping(int key)
        {
            var items = this.context.CustomerShippings.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnCustomerShippingGet(ref result);

            return result;
        }
        partial void OnCustomerShippingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnAfterCustomerShippingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);

        [HttpDelete("/odata/Throttle_Core_Billing/CustomerShippings(fldRecordID={fldRecordID})")]
        public IActionResult DeleteCustomerShipping(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.CustomerShippings
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnCustomerShippingDeleted(item);
                this.context.CustomerShippings.Remove(item);
                this.context.SaveChanges();
                this.OnAfterCustomerShippingDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCustomerShippingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnAfterCustomerShippingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);

        [HttpPut("/odata/Throttle_Core_Billing/CustomerShippings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutCustomerShipping(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item)
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
                this.OnCustomerShippingUpdated(item);
                this.context.CustomerShippings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CustomerShippings.Where(i => i.fldRecordID == key);
                
                this.OnAfterCustomerShippingUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/CustomerShippings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchCustomerShipping(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.CustomerShippings.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnCustomerShippingUpdated(item);
                this.context.CustomerShippings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CustomerShippings.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCustomerShippingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnAfterCustomerShippingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item)
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

                this.OnCustomerShippingCreated(item);
                this.context.CustomerShippings.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CustomerShippings.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterCustomerShippingCreated(item);

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
