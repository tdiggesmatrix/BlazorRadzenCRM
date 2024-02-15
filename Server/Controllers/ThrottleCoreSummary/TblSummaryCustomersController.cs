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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Summary
{
    [Route("odata/Throttle_Core_Summary/TblSummaryCustomers")]
    public partial class TblSummaryCustomersController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblSummaryCustomersController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> GetTblSummaryCustomers()
        {
            var items = this.context.TblSummaryCustomers.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>();
            this.OnTblSummaryCustomersRead(ref items);

            return items;
        }

        partial void OnTblSummaryCustomersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> items);

        partial void OnTblSummaryCustomerGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblSummaryCustomers(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> GetTblSummaryCustomer(int key)
        {
            var items = this.context.TblSummaryCustomers.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblSummaryCustomerGet(ref result);

            return result;
        }
        partial void OnTblSummaryCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnAfterTblSummaryCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblSummaryCustomers(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblSummaryCustomer(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblSummaryCustomers
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblSummaryCustomerDeleted(item);
                this.context.TblSummaryCustomers.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblSummaryCustomerDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummaryCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnAfterTblSummaryCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);

        [HttpPut("/odata/Throttle_Core_Summary/TblSummaryCustomers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblSummaryCustomer(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item)
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
                this.OnTblSummaryCustomerUpdated(item);
                this.context.TblSummaryCustomers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryCustomers.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblSummaryCustomerUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblSummaryCustomers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblSummaryCustomer(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblSummaryCustomers.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblSummaryCustomerUpdated(item);
                this.context.TblSummaryCustomers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryCustomers.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummaryCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnAfterTblSummaryCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item)
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

                this.OnTblSummaryCustomerCreated(item);
                this.context.TblSummaryCustomers.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryCustomers.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblSummaryCustomerCreated(item);

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
