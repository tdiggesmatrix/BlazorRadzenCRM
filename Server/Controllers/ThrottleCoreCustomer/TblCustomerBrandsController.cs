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
    [Route("odata/Throttle_Core_Customer/TblCustomerBrands")]
    public partial class TblCustomerBrandsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerBrandsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> GetTblCustomerBrands()
        {
            var items = this.context.TblCustomerBrands.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>();
            this.OnTblCustomerBrandsRead(ref items);

            return items;
        }

        partial void OnTblCustomerBrandsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> items);

        partial void OnTblCustomerBrandGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerBrands(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> GetTblCustomerBrand(int key)
        {
            var items = this.context.TblCustomerBrands.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerBrandGet(ref result);

            return result;
        }
        partial void OnTblCustomerBrandDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnAfterTblCustomerBrandDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerBrands(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerBrand(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerBrands
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerBrandDeleted(item);
                this.context.TblCustomerBrands.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerBrandDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerBrandUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnAfterTblCustomerBrandUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerBrands(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerBrand(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item)
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
                this.OnTblCustomerBrandUpdated(item);
                this.context.TblCustomerBrands.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerBrands.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerBrandUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerBrands(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerBrand(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerBrands.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerBrandUpdated(item);
                this.context.TblCustomerBrands.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerBrands.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerBrandCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnAfterTblCustomerBrandCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item)
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

                this.OnTblCustomerBrandCreated(item);
                this.context.TblCustomerBrands.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerBrands.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerBrandCreated(item);

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
