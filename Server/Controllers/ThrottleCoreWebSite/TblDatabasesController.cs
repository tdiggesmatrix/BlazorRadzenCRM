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
    [Route("odata/Throttle_Core_WebSite/TblDatabases")]
    public partial class TblDatabasesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblDatabasesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> GetTblDatabases()
        {
            var items = this.context.TblDatabases.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>();
            this.OnTblDatabasesRead(ref items);

            return items;
        }

        partial void OnTblDatabasesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> items);

        partial void OnTblDatabaseGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblDatabases(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> GetTblDatabase(int key)
        {
            var items = this.context.TblDatabases.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDatabaseGet(ref result);

            return result;
        }
        partial void OnTblDatabaseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnAfterTblDatabaseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblDatabases(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDatabase(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDatabases
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDatabaseDeleted(item);
                this.context.TblDatabases.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDatabaseDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDatabaseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnAfterTblDatabaseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblDatabases(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDatabase(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item)
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
                this.OnTblDatabaseUpdated(item);
                this.context.TblDatabases.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDatabases.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDatabaseUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblDatabases(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDatabase(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDatabases.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDatabaseUpdated(item);
                this.context.TblDatabases.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDatabases.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDatabaseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnAfterTblDatabaseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item)
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

                this.OnTblDatabaseCreated(item);
                this.context.TblDatabases.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDatabases.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDatabaseCreated(item);

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
