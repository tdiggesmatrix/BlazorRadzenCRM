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
    [Route("odata/Throttle_Core_Billing/Products")]
    public partial class ProductsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public ProductsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> GetProducts()
        {
            var items = this.context.Products.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>();
            this.OnProductsRead(ref items);

            return items;
        }

        partial void OnProductsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> items);

        partial void OnProductGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/Products(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> GetProduct(int key)
        {
            var items = this.context.Products.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnProductGet(ref result);

            return result;
        }
        partial void OnProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnAfterProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);

        [HttpDelete("/odata/Throttle_Core_Billing/Products(fldRecordID={fldRecordID})")]
        public IActionResult DeleteProduct(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Products
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProductDeleted(item);
                this.context.Products.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProductDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnAfterProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);

        [HttpPut("/odata/Throttle_Core_Billing/Products(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProduct(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item)
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
                this.OnProductUpdated(item);
                this.context.Products.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Products.Where(i => i.fldRecordID == key);
                
                this.OnAfterProductUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/Products(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProduct(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Products.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProductUpdated(item);
                this.context.Products.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Products.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnAfterProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item)
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

                this.OnProductCreated(item);
                this.context.Products.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Products.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterProductCreated(item);

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
