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
    [Route("odata/Throttle_Core_Billing/CurrentStores")]
    public partial class CurrentStoresController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public CurrentStoresController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> GetCurrentStores()
        {
            var items = this.context.CurrentStores.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>();
            this.OnCurrentStoresRead(ref items);

            return items;
        }

        partial void OnCurrentStoresRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> items);

        partial void OnCurrentStoreGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/CurrentStores(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> GetCurrentStore(int key)
        {
            var items = this.context.CurrentStores.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnCurrentStoreGet(ref result);

            return result;
        }
        partial void OnCurrentStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnAfterCurrentStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);

        [HttpDelete("/odata/Throttle_Core_Billing/CurrentStores(fldRecordID={fldRecordID})")]
        public IActionResult DeleteCurrentStore(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.CurrentStores
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnCurrentStoreDeleted(item);
                this.context.CurrentStores.Remove(item);
                this.context.SaveChanges();
                this.OnAfterCurrentStoreDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCurrentStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnAfterCurrentStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);

        [HttpPut("/odata/Throttle_Core_Billing/CurrentStores(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutCurrentStore(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item)
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
                this.OnCurrentStoreUpdated(item);
                this.context.CurrentStores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CurrentStores.Where(i => i.fldRecordID == key);
                
                this.OnAfterCurrentStoreUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/CurrentStores(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchCurrentStore(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.CurrentStores.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnCurrentStoreUpdated(item);
                this.context.CurrentStores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CurrentStores.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCurrentStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnAfterCurrentStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item)
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

                this.OnCurrentStoreCreated(item);
                this.context.CurrentStores.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.CurrentStores.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterCurrentStoreCreated(item);

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
