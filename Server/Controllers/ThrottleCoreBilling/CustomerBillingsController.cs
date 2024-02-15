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
    [Route("odata/Throttle_Core_Billing/CustomerBillings")]
    public partial class CustomerBillingsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public CustomerBillingsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> GetCustomerBillings()
        {
            var items = this.context.CustomerBillings.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>();
            this.OnCustomerBillingsRead(ref items);

            return items;
        }

        partial void OnCustomerBillingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> items);

        partial void OnCustomerBillingGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/CustomerBillings(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> GetCustomerBilling(int key)
        {
            var items = this.context.CustomerBillings.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnCustomerBillingGet(ref result);

            return result;
        }
        partial void OnCustomerBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnAfterCustomerBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);

        [HttpDelete("/odata/Throttle_Core_Billing/CustomerBillings(fldRecordID={fldRecordID})")]
        public IActionResult DeleteCustomerBilling(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.CustomerBillings
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnCustomerBillingDeleted(item);
                this.context.CustomerBillings.Remove(item);
                this.context.SaveChanges();
                this.OnAfterCustomerBillingDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCustomerBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnAfterCustomerBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);

        [HttpPut("/odata/Throttle_Core_Billing/CustomerBillings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutCustomerBilling(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item)
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
                this.OnCustomerBillingUpdated(item);
                this.context.CustomerBillings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CustomerBillings.Where(i => i.fldRecordID == key);
                
                this.OnAfterCustomerBillingUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/CustomerBillings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchCustomerBilling(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.CustomerBillings.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnCustomerBillingUpdated(item);
                this.context.CustomerBillings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CustomerBillings.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCustomerBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnAfterCustomerBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item)
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

                this.OnCustomerBillingCreated(item);
                this.context.CustomerBillings.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CustomerBillings.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterCustomerBillingCreated(item);

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
