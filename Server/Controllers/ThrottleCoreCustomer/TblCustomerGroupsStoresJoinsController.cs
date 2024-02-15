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
    [Route("odata/Throttle_Core_Customer/TblCustomerGroupsStoresJoins")]
    public partial class TblCustomerGroupsStoresJoinsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerGroupsStoresJoinsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> GetTblCustomerGroupsStoresJoins()
        {
            var items = this.context.TblCustomerGroupsStoresJoins.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>();
            this.OnTblCustomerGroupsStoresJoinsRead(ref items);

            return items;
        }

        partial void OnTblCustomerGroupsStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> items);

        partial void OnTblCustomerGroupsStoresJoinGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerGroupsStoresJoins(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> GetTblCustomerGroupsStoresJoin(int key)
        {
            var items = this.context.TblCustomerGroupsStoresJoins.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerGroupsStoresJoinGet(ref result);

            return result;
        }
        partial void OnTblCustomerGroupsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnAfterTblCustomerGroupsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerGroupsStoresJoins(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerGroupsStoresJoin(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerGroupsStoresJoins
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerGroupsStoresJoinDeleted(item);
                this.context.TblCustomerGroupsStoresJoins.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerGroupsStoresJoinDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerGroupsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnAfterTblCustomerGroupsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerGroupsStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerGroupsStoresJoin(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item)
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
                this.OnTblCustomerGroupsStoresJoinUpdated(item);
                this.context.TblCustomerGroupsStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerGroupsStoresJoins.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerGroupsStoresJoinUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerGroupsStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerGroupsStoresJoin(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerGroupsStoresJoins.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerGroupsStoresJoinUpdated(item);
                this.context.TblCustomerGroupsStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerGroupsStoresJoins.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerGroupsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnAfterTblCustomerGroupsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item)
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

                this.OnTblCustomerGroupsStoresJoinCreated(item);
                this.context.TblCustomerGroupsStoresJoins.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerGroupsStoresJoins.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerGroupsStoresJoinCreated(item);

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
