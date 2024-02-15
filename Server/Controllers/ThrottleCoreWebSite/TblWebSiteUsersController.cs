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
    [Route("odata/Throttle_Core_WebSite/TblWebSiteUsers")]
    public partial class TblWebSiteUsersController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblWebSiteUsersController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> GetTblWebSiteUsers()
        {
            var items = this.context.TblWebSiteUsers.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>();
            this.OnTblWebSiteUsersRead(ref items);

            return items;
        }

        partial void OnTblWebSiteUsersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> items);

        partial void OnTblWebSiteUserGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblWebSiteUsers(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> GetTblWebSiteUser(int key)
        {
            var items = this.context.TblWebSiteUsers.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblWebSiteUserGet(ref result);

            return result;
        }
        partial void OnTblWebSiteUserDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnAfterTblWebSiteUserDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblWebSiteUsers(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblWebSiteUser(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblWebSiteUsers
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblWebSiteUserDeleted(item);
                this.context.TblWebSiteUsers.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblWebSiteUserDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteUserUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnAfterTblWebSiteUserUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblWebSiteUsers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblWebSiteUser(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item)
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
                this.OnTblWebSiteUserUpdated(item);
                this.context.TblWebSiteUsers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteUsers.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblWebSiteUserUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblWebSiteUsers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblWebSiteUser(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblWebSiteUsers.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblWebSiteUserUpdated(item);
                this.context.TblWebSiteUsers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteUsers.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteUserCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnAfterTblWebSiteUserCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item)
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

                this.OnTblWebSiteUserCreated(item);
                this.context.TblWebSiteUsers.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteUsers.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblWebSiteUserCreated(item);

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
