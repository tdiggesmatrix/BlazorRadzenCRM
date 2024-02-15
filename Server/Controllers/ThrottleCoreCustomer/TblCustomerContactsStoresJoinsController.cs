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
    [Route("odata/Throttle_Core_Customer/TblCustomerContactsStoresJoins")]
    public partial class TblCustomerContactsStoresJoinsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerContactsStoresJoinsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> GetTblCustomerContactsStoresJoins()
        {
            var items = this.context.TblCustomerContactsStoresJoins.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>();
            this.OnTblCustomerContactsStoresJoinsRead(ref items);

            return items;
        }

        partial void OnTblCustomerContactsStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> items);

        partial void OnTblCustomerContactsStoresJoinGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerContactsStoresJoins(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> GetTblCustomerContactsStoresJoin(int key)
        {
            var items = this.context.TblCustomerContactsStoresJoins.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerContactsStoresJoinGet(ref result);

            return result;
        }
        partial void OnTblCustomerContactsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnAfterTblCustomerContactsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerContactsStoresJoins(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerContactsStoresJoin(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerContactsStoresJoins
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerContactsStoresJoinDeleted(item);
                this.context.TblCustomerContactsStoresJoins.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerContactsStoresJoinDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerContactsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnAfterTblCustomerContactsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerContactsStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerContactsStoresJoin(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item)
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
                this.OnTblCustomerContactsStoresJoinUpdated(item);
                this.context.TblCustomerContactsStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerContactsStoresJoins.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerContactsStoresJoinUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerContactsStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerContactsStoresJoin(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerContactsStoresJoins.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerContactsStoresJoinUpdated(item);
                this.context.TblCustomerContactsStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerContactsStoresJoins.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerContactsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnAfterTblCustomerContactsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item)
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

                this.OnTblCustomerContactsStoresJoinCreated(item);
                this.context.TblCustomerContactsStoresJoins.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerContactsStoresJoins.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerContactsStoresJoinCreated(item);

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
