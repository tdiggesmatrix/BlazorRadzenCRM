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
    [Route("odata/Throttle_Core_WebSite/TblWebSiteErrorDescriptions")]
    public partial class TblWebSiteErrorDescriptionsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblWebSiteErrorDescriptionsController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> GetTblWebSiteErrorDescriptions()
        {
            var items = this.context.TblWebSiteErrorDescriptions.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>();
            this.OnTblWebSiteErrorDescriptionsRead(ref items);

            return items;
        }

        partial void OnTblWebSiteErrorDescriptionsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> items);

        partial void OnTblWebSiteErrorDescriptionGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblWebSiteErrorDescriptions(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> GetTblWebSiteErrorDescription(int key)
        {
            var items = this.context.TblWebSiteErrorDescriptions.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblWebSiteErrorDescriptionGet(ref result);

            return result;
        }
        partial void OnTblWebSiteErrorDescriptionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnAfterTblWebSiteErrorDescriptionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblWebSiteErrorDescriptions(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblWebSiteErrorDescription(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblWebSiteErrorDescriptions
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblWebSiteErrorDescriptionDeleted(item);
                this.context.TblWebSiteErrorDescriptions.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblWebSiteErrorDescriptionDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteErrorDescriptionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnAfterTblWebSiteErrorDescriptionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblWebSiteErrorDescriptions(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblWebSiteErrorDescription(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item)
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
                this.OnTblWebSiteErrorDescriptionUpdated(item);
                this.context.TblWebSiteErrorDescriptions.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteErrorDescriptions.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblWebSiteErrorDescriptionUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblWebSiteErrorDescriptions(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblWebSiteErrorDescription(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblWebSiteErrorDescriptions.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblWebSiteErrorDescriptionUpdated(item);
                this.context.TblWebSiteErrorDescriptions.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteErrorDescriptions.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteErrorDescriptionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnAfterTblWebSiteErrorDescriptionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item)
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

                this.OnTblWebSiteErrorDescriptionCreated(item);
                this.context.TblWebSiteErrorDescriptions.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteErrorDescriptions.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblWebSiteErrorDescriptionCreated(item);

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
