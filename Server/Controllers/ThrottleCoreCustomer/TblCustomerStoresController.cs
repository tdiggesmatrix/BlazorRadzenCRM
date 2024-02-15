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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Customer
{
    [Route("odata/Throttle_Core_Customer/TblCustomerStores")]
    public partial class TblCustomerStoresController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerStoresController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> GetTblCustomerStores()
        {
            var items = this.context.TblCustomerStores.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>();
            this.OnTblCustomerStoresRead(ref items);

            return items;
        }

        partial void OnTblCustomerStoresRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> items);

        partial void OnTblCustomerStoreGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerStores(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> GetTblCustomerStore(int key)
        {
            var items = this.context.TblCustomerStores.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerStoreGet(ref result);

            return result;
        }
        partial void OnTblCustomerStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnAfterTblCustomerStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerStores(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerStore(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerStores
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerStoreDeleted(item);
                this.context.TblCustomerStores.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerStoreDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnAfterTblCustomerStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerStores(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerStore(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item)
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
                this.OnTblCustomerStoreUpdated(item);
                this.context.TblCustomerStores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerStores.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerStoreUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerStores(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerStore(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerStores.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerStoreUpdated(item);
                this.context.TblCustomerStores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerStores.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnAfterTblCustomerStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item)
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

                this.OnTblCustomerStoreCreated(item);
                this.context.TblCustomerStores.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerStores.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerStoreCreated(item);

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
