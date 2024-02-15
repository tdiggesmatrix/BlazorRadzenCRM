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
    [Route("odata/Throttle_Core_WebSite/TblWebSiteSecurityGroups")]
    public partial class TblWebSiteSecurityGroupsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblWebSiteSecurityGroupsController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> GetTblWebSiteSecurityGroups()
        {
            var items = this.context.TblWebSiteSecurityGroups.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>();
            this.OnTblWebSiteSecurityGroupsRead(ref items);

            return items;
        }

        partial void OnTblWebSiteSecurityGroupsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> items);

        partial void OnTblWebSiteSecurityGroupGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblWebSiteSecurityGroups(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> GetTblWebSiteSecurityGroup(int key)
        {
            var items = this.context.TblWebSiteSecurityGroups.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblWebSiteSecurityGroupGet(ref result);

            return result;
        }
        partial void OnTblWebSiteSecurityGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnAfterTblWebSiteSecurityGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblWebSiteSecurityGroups(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblWebSiteSecurityGroup(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblWebSiteSecurityGroups
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblWebSiteSecurityGroupDeleted(item);
                this.context.TblWebSiteSecurityGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblWebSiteSecurityGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteSecurityGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnAfterTblWebSiteSecurityGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblWebSiteSecurityGroups(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblWebSiteSecurityGroup(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item)
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
                this.OnTblWebSiteSecurityGroupUpdated(item);
                this.context.TblWebSiteSecurityGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteSecurityGroups.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblWebSiteSecurityGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblWebSiteSecurityGroups(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblWebSiteSecurityGroup(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblWebSiteSecurityGroups.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblWebSiteSecurityGroupUpdated(item);
                this.context.TblWebSiteSecurityGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteSecurityGroups.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteSecurityGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnAfterTblWebSiteSecurityGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item)
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

                this.OnTblWebSiteSecurityGroupCreated(item);
                this.context.TblWebSiteSecurityGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteSecurityGroups.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblWebSiteSecurityGroupCreated(item);

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
