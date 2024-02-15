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
    [Route("odata/Throttle_Core_Customer/TblCustomerGroups")]
    public partial class TblCustomerGroupsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerGroupsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> GetTblCustomerGroups()
        {
            var items = this.context.TblCustomerGroups.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>();
            this.OnTblCustomerGroupsRead(ref items);

            return items;
        }

        partial void OnTblCustomerGroupsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> items);

        partial void OnTblCustomerGroupGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerGroups(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> GetTblCustomerGroup(int key)
        {
            var items = this.context.TblCustomerGroups.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerGroupGet(ref result);

            return result;
        }
        partial void OnTblCustomerGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnAfterTblCustomerGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerGroups(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerGroup(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerGroups
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerGroupDeleted(item);
                this.context.TblCustomerGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnAfterTblCustomerGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerGroups(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerGroup(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item)
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
                this.OnTblCustomerGroupUpdated(item);
                this.context.TblCustomerGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerGroups.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerGroups(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerGroup(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerGroups.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerGroupUpdated(item);
                this.context.TblCustomerGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerGroups.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnAfterTblCustomerGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item)
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

                this.OnTblCustomerGroupCreated(item);
                this.context.TblCustomerGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerGroups.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerGroupCreated(item);

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
