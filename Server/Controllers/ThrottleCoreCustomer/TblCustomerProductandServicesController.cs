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
    [Route("odata/Throttle_Core_Customer/TblCustomerProductandServices")]
    public partial class TblCustomerProductandServicesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerProductandServicesController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> GetTblCustomerProductandServices()
        {
            var items = this.context.TblCustomerProductandServices.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>();
            this.OnTblCustomerProductandServicesRead(ref items);

            return items;
        }

        partial void OnTblCustomerProductandServicesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> items);

        partial void OnTblCustomerProductandServiceGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerProductandServices(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> GetTblCustomerProductandService(int key)
        {
            var items = this.context.TblCustomerProductandServices.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerProductandServiceGet(ref result);

            return result;
        }
        partial void OnTblCustomerProductandServiceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnAfterTblCustomerProductandServiceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerProductandServices(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerProductandService(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerProductandServices
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerProductandServiceDeleted(item);
                this.context.TblCustomerProductandServices.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerProductandServiceDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerProductandServiceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnAfterTblCustomerProductandServiceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerProductandServices(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerProductandService(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item)
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
                this.OnTblCustomerProductandServiceUpdated(item);
                this.context.TblCustomerProductandServices.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerProductandServices.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerProductandServiceUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerProductandServices(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerProductandService(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerProductandServices.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerProductandServiceUpdated(item);
                this.context.TblCustomerProductandServices.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerProductandServices.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerProductandServiceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnAfterTblCustomerProductandServiceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item)
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

                this.OnTblCustomerProductandServiceCreated(item);
                this.context.TblCustomerProductandServices.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerProductandServices.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerProductandServiceCreated(item);

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
