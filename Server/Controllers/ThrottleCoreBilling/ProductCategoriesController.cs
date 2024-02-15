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
    [Route("odata/Throttle_Core_Billing/ProductCategories")]
    public partial class ProductCategoriesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public ProductCategoriesController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> GetProductCategories()
        {
            var items = this.context.ProductCategories.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>();
            this.OnProductCategoriesRead(ref items);

            return items;
        }

        partial void OnProductCategoriesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> items);

        partial void OnProductCategoryGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/ProductCategories(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> GetProductCategory(int key)
        {
            var items = this.context.ProductCategories.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnProductCategoryGet(ref result);

            return result;
        }
        partial void OnProductCategoryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnAfterProductCategoryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);

        [HttpDelete("/odata/Throttle_Core_Billing/ProductCategories(fldRecordID={fldRecordID})")]
        public IActionResult DeleteProductCategory(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.ProductCategories
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnProductCategoryDeleted(item);
                this.context.ProductCategories.Remove(item);
                this.context.SaveChanges();
                this.OnAfterProductCategoryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProductCategoryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnAfterProductCategoryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);

        [HttpPut("/odata/Throttle_Core_Billing/ProductCategories(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutProductCategory(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item)
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
                this.OnProductCategoryUpdated(item);
                this.context.ProductCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProductCategories.Where(i => i.fldRecordID == key);
                
                this.OnAfterProductCategoryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/ProductCategories(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchProductCategory(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.ProductCategories.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnProductCategoryUpdated(item);
                this.context.ProductCategories.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProductCategories.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnProductCategoryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnAfterProductCategoryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item)
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

                this.OnProductCategoryCreated(item);
                this.context.ProductCategories.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.ProductCategories.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterProductCategoryCreated(item);

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
