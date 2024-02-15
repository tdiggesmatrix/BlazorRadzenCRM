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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Billing
{
    [Route("odata/Throttle_Core_Billing/Jobs")]
    public partial class JobsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public JobsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> GetJobs()
        {
            var items = this.context.Jobs.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>();
            this.OnJobsRead(ref items);

            return items;
        }

        partial void OnJobsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> items);

        partial void OnJobGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/Jobs(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> GetJob(int key)
        {
            var items = this.context.Jobs.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnJobGet(ref result);

            return result;
        }
        partial void OnJobDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnAfterJobDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);

        [HttpDelete("/odata/Throttle_Core_Billing/Jobs(fldRecordID={fldRecordID})")]
        public IActionResult DeleteJob(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Jobs
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnJobDeleted(item);
                this.context.Jobs.Remove(item);
                this.context.SaveChanges();
                this.OnAfterJobDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnJobUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnAfterJobUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);

        [HttpPut("/odata/Throttle_Core_Billing/Jobs(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutJob(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item)
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
                this.OnJobUpdated(item);
                this.context.Jobs.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Jobs.Where(i => i.fldRecordID == key);
                
                this.OnAfterJobUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/Jobs(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchJob(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Jobs.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnJobUpdated(item);
                this.context.Jobs.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Jobs.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnJobCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnAfterJobCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item)
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

                this.OnJobCreated(item);
                this.context.Jobs.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Jobs.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterJobCreated(item);

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
