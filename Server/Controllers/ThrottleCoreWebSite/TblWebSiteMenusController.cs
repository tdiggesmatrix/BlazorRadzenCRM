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
    [Route("odata/Throttle_Core_WebSite/TblWebSiteMenus")]
    public partial class TblWebSiteMenusController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblWebSiteMenusController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> GetTblWebSiteMenus()
        {
            var items = this.context.TblWebSiteMenus.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>();
            this.OnTblWebSiteMenusRead(ref items);

            return items;
        }

        partial void OnTblWebSiteMenusRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> items);

        partial void OnTblWebSiteMenuGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblWebSiteMenus(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> GetTblWebSiteMenu(int key)
        {
            var items = this.context.TblWebSiteMenus.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblWebSiteMenuGet(ref result);

            return result;
        }
        partial void OnTblWebSiteMenuDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnAfterTblWebSiteMenuDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblWebSiteMenus(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblWebSiteMenu(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblWebSiteMenus
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblWebSiteMenuDeleted(item);
                this.context.TblWebSiteMenus.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblWebSiteMenuDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteMenuUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnAfterTblWebSiteMenuUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblWebSiteMenus(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblWebSiteMenu(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item)
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
                this.OnTblWebSiteMenuUpdated(item);
                this.context.TblWebSiteMenus.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteMenus.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblWebSiteMenuUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblWebSiteMenus(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblWebSiteMenu(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblWebSiteMenus.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblWebSiteMenuUpdated(item);
                this.context.TblWebSiteMenus.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteMenus.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteMenuCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnAfterTblWebSiteMenuCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item)
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

                this.OnTblWebSiteMenuCreated(item);
                this.context.TblWebSiteMenus.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteMenus.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblWebSiteMenuCreated(item);

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
