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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_WebSite
{
    [Route("odata/Throttle_Core_WebSite/OpportunityStatuses")]
    public partial class OpportunityStatusesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public OpportunityStatusesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> GetOpportunityStatuses()
        {
            var items = this.context.OpportunityStatuses.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>();
            this.OnOpportunityStatusesRead(ref items);

            return items;
        }

        partial void OnOpportunityStatusesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> items);

        partial void OnOpportunityStatusGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/OpportunityStatuses(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> GetOpportunityStatus(int key)
        {
            var items = this.context.OpportunityStatuses.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnOpportunityStatusGet(ref result);

            return result;
        }
        partial void OnOpportunityStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnAfterOpportunityStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);

        [HttpDelete("/odata/Throttle_Core_WebSite/OpportunityStatuses(Id={Id})")]
        public IActionResult DeleteOpportunityStatus(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.OpportunityStatuses
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnOpportunityStatusDeleted(item);
                this.context.OpportunityStatuses.Remove(item);
                this.context.SaveChanges();
                this.OnAfterOpportunityStatusDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnOpportunityStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnAfterOpportunityStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);

        [HttpPut("/odata/Throttle_Core_WebSite/OpportunityStatuses(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutOpportunityStatus(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != key))
                {
                    return BadRequest();
                }
                this.OnOpportunityStatusUpdated(item);
                this.context.OpportunityStatuses.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.OpportunityStatuses.Where(i => i.Id == key);
                
                this.OnAfterOpportunityStatusUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/OpportunityStatuses(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchOpportunityStatus(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.OpportunityStatuses.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnOpportunityStatusUpdated(item);
                this.context.OpportunityStatuses.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.OpportunityStatuses.Where(i => i.Id == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnOpportunityStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnAfterOpportunityStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item)
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

                this.OnOpportunityStatusCreated(item);
                this.context.OpportunityStatuses.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.OpportunityStatuses.Where(i => i.Id == item.Id);

                

                this.OnAfterOpportunityStatusCreated(item);

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
