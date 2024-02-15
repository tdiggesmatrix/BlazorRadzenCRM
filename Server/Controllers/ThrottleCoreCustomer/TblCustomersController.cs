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
    [Route("odata/Throttle_Core_Customer/TblCustomers")]
    public partial class TblCustomersController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomersController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> GetTblCustomers()
        {
            var items = this.context.TblCustomers.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>();
            this.OnTblCustomersRead(ref items);

            return items;
        }

        partial void OnTblCustomersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> items);

        partial void OnTblCustomerGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomers(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> GetTblCustomer(int key)
        {
            var items = this.context.TblCustomers.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerGet(ref result);

            return result;
        }
        partial void OnTblCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnAfterTblCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomers(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomer(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomers
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerDeleted(item);
                this.context.TblCustomers.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnAfterTblCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomer(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item)
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
                this.OnTblCustomerUpdated(item);
                this.context.TblCustomers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomers.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomer(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomers.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerUpdated(item);
                this.context.TblCustomers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomers.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnAfterTblCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item)
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

                this.OnTblCustomerCreated(item);
                this.context.TblCustomers.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomers.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerCreated(item);

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
