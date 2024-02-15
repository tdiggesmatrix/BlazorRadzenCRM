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
    [Route("odata/Throttle_Core_WebSite/Opportunities")]
    public partial class OpportunitiesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public OpportunitiesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> GetOpportunities()
        {
            var items = this.context.Opportunities.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>();
            this.OnOpportunitiesRead(ref items);

            return items;
        }

        partial void OnOpportunitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> items);

        partial void OnOpportunityGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/Opportunities(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> GetOpportunity(int key)
        {
            var items = this.context.Opportunities.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnOpportunityGet(ref result);

            return result;
        }
        partial void OnOpportunityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnAfterOpportunityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);

        [HttpDelete("/odata/Throttle_Core_WebSite/Opportunities(Id={Id})")]
        public IActionResult DeleteOpportunity(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Opportunities
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnOpportunityDeleted(item);
                this.context.Opportunities.Remove(item);
                this.context.SaveChanges();
                this.OnAfterOpportunityDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnOpportunityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnAfterOpportunityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);

        [HttpPut("/odata/Throttle_Core_WebSite/Opportunities(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutOpportunity(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item)
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
                this.OnOpportunityUpdated(item);
                this.context.Opportunities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Opportunities.Where(i => i.Id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Contact,OpportunityStatus");
                this.OnAfterOpportunityUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/Opportunities(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchOpportunity(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Opportunities.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnOpportunityUpdated(item);
                this.context.Opportunities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Opportunities.Where(i => i.Id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Contact,OpportunityStatus");
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnOpportunityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnAfterOpportunityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item)
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

                this.OnOpportunityCreated(item);
                this.context.Opportunities.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Opportunities.Where(i => i.Id == item.Id);

                Request.QueryString = Request.QueryString.Add("$expand", "Contact,OpportunityStatus");

                this.OnAfterOpportunityCreated(item);

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
