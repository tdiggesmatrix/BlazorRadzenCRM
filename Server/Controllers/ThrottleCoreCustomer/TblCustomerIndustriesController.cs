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
    [Route("odata/Throttle_Core_Customer/TblCustomerIndustries")]
    public partial class TblCustomerIndustriesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerIndustriesController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> GetTblCustomerIndustries()
        {
            var items = this.context.TblCustomerIndustries.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>();
            this.OnTblCustomerIndustriesRead(ref items);

            return items;
        }

        partial void OnTblCustomerIndustriesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> items);

        partial void OnTblCustomerIndustryGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerIndustries(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> GetTblCustomerIndustry(int key)
        {
            var items = this.context.TblCustomerIndustries.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerIndustryGet(ref result);

            return result;
        }
        partial void OnTblCustomerIndustryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnAfterTblCustomerIndustryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerIndustries(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerIndustry(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerIndustries
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerIndustryDeleted(item);
                this.context.TblCustomerIndustries.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerIndustryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerIndustryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnAfterTblCustomerIndustryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerIndustries(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerIndustry(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item)
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
                this.OnTblCustomerIndustryUpdated(item);
                this.context.TblCustomerIndustries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerIndustries.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerIndustryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerIndustries(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerIndustry(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerIndustries.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerIndustryUpdated(item);
                this.context.TblCustomerIndustries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerIndustries.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerIndustryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnAfterTblCustomerIndustryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item)
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

                this.OnTblCustomerIndustryCreated(item);
                this.context.TblCustomerIndustries.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerIndustries.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerIndustryCreated(item);

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
