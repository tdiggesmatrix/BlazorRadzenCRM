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
    [Route("odata/Throttle_Core_Customer/TblCustomerBrandsStoresJoins")]
    public partial class TblCustomerBrandsStoresJoinsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerBrandsStoresJoinsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> GetTblCustomerBrandsStoresJoins()
        {
            var items = this.context.TblCustomerBrandsStoresJoins.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>();
            this.OnTblCustomerBrandsStoresJoinsRead(ref items);

            return items;
        }

        partial void OnTblCustomerBrandsStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> items);

        partial void OnTblCustomerBrandsStoresJoinGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerBrandsStoresJoins(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> GetTblCustomerBrandsStoresJoin(int key)
        {
            var items = this.context.TblCustomerBrandsStoresJoins.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerBrandsStoresJoinGet(ref result);

            return result;
        }
        partial void OnTblCustomerBrandsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnAfterTblCustomerBrandsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerBrandsStoresJoins(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerBrandsStoresJoin(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerBrandsStoresJoins
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerBrandsStoresJoinDeleted(item);
                this.context.TblCustomerBrandsStoresJoins.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerBrandsStoresJoinDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerBrandsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnAfterTblCustomerBrandsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerBrandsStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerBrandsStoresJoin(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item)
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
                this.OnTblCustomerBrandsStoresJoinUpdated(item);
                this.context.TblCustomerBrandsStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerBrandsStoresJoins.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerBrandsStoresJoinUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerBrandsStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerBrandsStoresJoin(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerBrandsStoresJoins.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerBrandsStoresJoinUpdated(item);
                this.context.TblCustomerBrandsStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerBrandsStoresJoins.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerBrandsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnAfterTblCustomerBrandsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item)
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

                this.OnTblCustomerBrandsStoresJoinCreated(item);
                this.context.TblCustomerBrandsStoresJoins.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerBrandsStoresJoins.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerBrandsStoresJoinCreated(item);

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
