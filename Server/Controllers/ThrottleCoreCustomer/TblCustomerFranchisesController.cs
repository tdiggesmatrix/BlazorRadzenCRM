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
    [Route("odata/Throttle_Core_Customer/TblCustomerFranchises")]
    public partial class TblCustomerFranchisesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerFranchisesController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> GetTblCustomerFranchises()
        {
            var items = this.context.TblCustomerFranchises.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>();
            this.OnTblCustomerFranchisesRead(ref items);

            return items;
        }

        partial void OnTblCustomerFranchisesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> items);

        partial void OnTblCustomerFranchiseGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerFranchises(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> GetTblCustomerFranchise(int key)
        {
            var items = this.context.TblCustomerFranchises.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerFranchiseGet(ref result);

            return result;
        }
        partial void OnTblCustomerFranchiseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnAfterTblCustomerFranchiseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerFranchises(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerFranchise(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerFranchises
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerFranchiseDeleted(item);
                this.context.TblCustomerFranchises.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerFranchiseDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerFranchiseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnAfterTblCustomerFranchiseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerFranchises(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerFranchise(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item)
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
                this.OnTblCustomerFranchiseUpdated(item);
                this.context.TblCustomerFranchises.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerFranchises.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerFranchiseUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerFranchises(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerFranchise(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerFranchises.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerFranchiseUpdated(item);
                this.context.TblCustomerFranchises.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerFranchises.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerFranchiseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnAfterTblCustomerFranchiseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item)
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

                this.OnTblCustomerFranchiseCreated(item);
                this.context.TblCustomerFranchises.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerFranchises.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerFranchiseCreated(item);

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
