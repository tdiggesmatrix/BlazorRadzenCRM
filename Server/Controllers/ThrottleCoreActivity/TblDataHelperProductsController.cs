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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Activity
{
    [Route("odata/Throttle_Core_Activity/TblDataHelperProducts")]
    public partial class TblDataHelperProductsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataHelperProductsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> GetTblDataHelperProducts()
        {
            var items = this.context.TblDataHelperProducts.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>();
            this.OnTblDataHelperProductsRead(ref items);

            return items;
        }

        partial void OnTblDataHelperProductsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> items);

        partial void OnTblDataHelperProductGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataHelperProducts(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> GetTblDataHelperProduct(int key)
        {
            var items = this.context.TblDataHelperProducts.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataHelperProductGet(ref result);

            return result;
        }
        partial void OnTblDataHelperProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnAfterTblDataHelperProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataHelperProducts(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataHelperProduct(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataHelperProducts
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataHelperProductDeleted(item);
                this.context.TblDataHelperProducts.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataHelperProductDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnAfterTblDataHelperProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataHelperProducts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataHelperProduct(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item)
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
                this.OnTblDataHelperProductUpdated(item);
                this.context.TblDataHelperProducts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperProducts.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataHelperProductUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataHelperProducts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataHelperProduct(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataHelperProducts.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataHelperProductUpdated(item);
                this.context.TblDataHelperProducts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperProducts.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnAfterTblDataHelperProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item)
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

                this.OnTblDataHelperProductCreated(item);
                this.context.TblDataHelperProducts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperProducts.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataHelperProductCreated(item);

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
