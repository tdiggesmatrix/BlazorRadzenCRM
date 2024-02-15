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
    [Route("odata/Throttle_Core_Customer/TblCustomerFranchisesStoresJoins")]
    public partial class TblCustomerFranchisesStoresJoinsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerFranchisesStoresJoinsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> GetTblCustomerFranchisesStoresJoins()
        {
            var items = this.context.TblCustomerFranchisesStoresJoins.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>();
            this.OnTblCustomerFranchisesStoresJoinsRead(ref items);

            return items;
        }

        partial void OnTblCustomerFranchisesStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> items);

        partial void OnTblCustomerFranchisesStoresJoinGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerFranchisesStoresJoins(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> GetTblCustomerFranchisesStoresJoin(int key)
        {
            var items = this.context.TblCustomerFranchisesStoresJoins.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerFranchisesStoresJoinGet(ref result);

            return result;
        }
        partial void OnTblCustomerFranchisesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnAfterTblCustomerFranchisesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerFranchisesStoresJoins(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerFranchisesStoresJoin(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerFranchisesStoresJoins
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerFranchisesStoresJoinDeleted(item);
                this.context.TblCustomerFranchisesStoresJoins.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerFranchisesStoresJoinDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerFranchisesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnAfterTblCustomerFranchisesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerFranchisesStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerFranchisesStoresJoin(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item)
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
                this.OnTblCustomerFranchisesStoresJoinUpdated(item);
                this.context.TblCustomerFranchisesStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerFranchisesStoresJoins.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerFranchisesStoresJoinUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerFranchisesStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerFranchisesStoresJoin(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerFranchisesStoresJoins.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerFranchisesStoresJoinUpdated(item);
                this.context.TblCustomerFranchisesStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerFranchisesStoresJoins.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerFranchisesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnAfterTblCustomerFranchisesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item)
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

                this.OnTblCustomerFranchisesStoresJoinCreated(item);
                this.context.TblCustomerFranchisesStoresJoins.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerFranchisesStoresJoins.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerFranchisesStoresJoinCreated(item);

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
