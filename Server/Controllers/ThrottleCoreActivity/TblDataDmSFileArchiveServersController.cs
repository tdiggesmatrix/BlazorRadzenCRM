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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Activity
{
    [Route("odata/Throttle_Core_Activity/TblDataDmSFileArchiveServers")]
    public partial class TblDataDmSFileArchiveServersController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataDmSFileArchiveServersController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> GetTblDataDmSFileArchiveServers()
        {
            var items = this.context.TblDataDmSFileArchiveServers.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>();
            this.OnTblDataDmSFileArchiveServersRead(ref items);

            return items;
        }

        partial void OnTblDataDmSFileArchiveServersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> items);

        partial void OnTblDataDmSFileArchiveServerGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveServers(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> GetTblDataDmSFileArchiveServer(int key)
        {
            var items = this.context.TblDataDmSFileArchiveServers.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataDmSFileArchiveServerGet(ref result);

            return result;
        }
        partial void OnTblDataDmSFileArchiveServerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnAfterTblDataDmSFileArchiveServerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveServers(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataDmSFileArchiveServer(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataDmSFileArchiveServers
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataDmSFileArchiveServerDeleted(item);
                this.context.TblDataDmSFileArchiveServers.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataDmSFileArchiveServerDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFileArchiveServerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnAfterTblDataDmSFileArchiveServerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveServers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataDmSFileArchiveServer(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item)
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
                this.OnTblDataDmSFileArchiveServerUpdated(item);
                this.context.TblDataDmSFileArchiveServers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileArchiveServers.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataDmSFileArchiveServerUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveServers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataDmSFileArchiveServer(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataDmSFileArchiveServers.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataDmSFileArchiveServerUpdated(item);
                this.context.TblDataDmSFileArchiveServers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileArchiveServers.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFileArchiveServerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnAfterTblDataDmSFileArchiveServerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item)
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

                this.OnTblDataDmSFileArchiveServerCreated(item);
                this.context.TblDataDmSFileArchiveServers.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileArchiveServers.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataDmSFileArchiveServerCreated(item);

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
