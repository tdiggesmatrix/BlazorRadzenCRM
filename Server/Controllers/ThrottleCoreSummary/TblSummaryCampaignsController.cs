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
    [Route("odata/Throttle_Core_Summary/TblSummaryCampaigns")]
    public partial class TblSummaryCampaignsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblSummaryCampaignsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> GetTblSummaryCampaigns()
        {
            var items = this.context.TblSummaryCampaigns.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>();
            this.OnTblSummaryCampaignsRead(ref items);

            return items;
        }

        partial void OnTblSummaryCampaignsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> items);

        partial void OnTblSummaryCampaignGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblSummaryCampaigns(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> GetTblSummaryCampaign(int key)
        {
            var items = this.context.TblSummaryCampaigns.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblSummaryCampaignGet(ref result);

            return result;
        }
        partial void OnTblSummaryCampaignDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnAfterTblSummaryCampaignDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblSummaryCampaigns(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblSummaryCampaign(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblSummaryCampaigns
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblSummaryCampaignDeleted(item);
                this.context.TblSummaryCampaigns.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblSummaryCampaignDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummaryCampaignUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnAfterTblSummaryCampaignUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);

        [HttpPut("/odata/Throttle_Core_Summary/TblSummaryCampaigns(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblSummaryCampaign(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item)
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
                this.OnTblSummaryCampaignUpdated(item);
                this.context.TblSummaryCampaigns.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryCampaigns.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblSummaryCampaignUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblSummaryCampaigns(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblSummaryCampaign(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblSummaryCampaigns.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblSummaryCampaignUpdated(item);
                this.context.TblSummaryCampaigns.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryCampaigns.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummaryCampaignCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnAfterTblSummaryCampaignCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item)
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

                this.OnTblSummaryCampaignCreated(item);
                this.context.TblSummaryCampaigns.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummaryCampaigns.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblSummaryCampaignCreated(item);

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
