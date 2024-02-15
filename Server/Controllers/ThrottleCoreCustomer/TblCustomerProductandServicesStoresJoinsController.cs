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
    [Route("odata/Throttle_Core_Customer/TblCustomerProductandServicesStoresJoins")]
    public partial class TblCustomerProductandServicesStoresJoinsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerProductandServicesStoresJoinsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> GetTblCustomerProductandServicesStoresJoins()
        {
            var items = this.context.TblCustomerProductandServicesStoresJoins.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>();
            this.OnTblCustomerProductandServicesStoresJoinsRead(ref items);

            return items;
        }

        partial void OnTblCustomerProductandServicesStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> items);

        partial void OnTblCustomerProductandServicesStoresJoinGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerProductandServicesStoresJoins(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> GetTblCustomerProductandServicesStoresJoin(int key)
        {
            var items = this.context.TblCustomerProductandServicesStoresJoins.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerProductandServicesStoresJoinGet(ref result);

            return result;
        }
        partial void OnTblCustomerProductandServicesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnAfterTblCustomerProductandServicesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerProductandServicesStoresJoins(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerProductandServicesStoresJoin(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerProductandServicesStoresJoins
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerProductandServicesStoresJoinDeleted(item);
                this.context.TblCustomerProductandServicesStoresJoins.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerProductandServicesStoresJoinDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerProductandServicesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnAfterTblCustomerProductandServicesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerProductandServicesStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerProductandServicesStoresJoin(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item)
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
                this.OnTblCustomerProductandServicesStoresJoinUpdated(item);
                this.context.TblCustomerProductandServicesStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerProductandServicesStoresJoins.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerProductandServicesStoresJoinUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerProductandServicesStoresJoins(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerProductandServicesStoresJoin(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerProductandServicesStoresJoins.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerProductandServicesStoresJoinUpdated(item);
                this.context.TblCustomerProductandServicesStoresJoins.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerProductandServicesStoresJoins.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerProductandServicesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnAfterTblCustomerProductandServicesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item)
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

                this.OnTblCustomerProductandServicesStoresJoinCreated(item);
                this.context.TblCustomerProductandServicesStoresJoins.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerProductandServicesStoresJoins.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerProductandServicesStoresJoinCreated(item);

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
