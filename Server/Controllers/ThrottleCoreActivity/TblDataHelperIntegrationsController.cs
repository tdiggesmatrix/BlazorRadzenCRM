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
    [Route("odata/Throttle_Core_Activity/TblDataHelperIntegrations")]
    public partial class TblDataHelperIntegrationsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataHelperIntegrationsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> GetTblDataHelperIntegrations()
        {
            var items = this.context.TblDataHelperIntegrations.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>();
            this.OnTblDataHelperIntegrationsRead(ref items);

            return items;
        }

        partial void OnTblDataHelperIntegrationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> items);

        partial void OnTblDataHelperIntegrationGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataHelperIntegrations(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> GetTblDataHelperIntegration(int key)
        {
            var items = this.context.TblDataHelperIntegrations.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataHelperIntegrationGet(ref result);

            return result;
        }
        partial void OnTblDataHelperIntegrationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnAfterTblDataHelperIntegrationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataHelperIntegrations(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataHelperIntegration(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataHelperIntegrations
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataHelperIntegrationDeleted(item);
                this.context.TblDataHelperIntegrations.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataHelperIntegrationDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperIntegrationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnAfterTblDataHelperIntegrationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataHelperIntegrations(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataHelperIntegration(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item)
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
                this.OnTblDataHelperIntegrationUpdated(item);
                this.context.TblDataHelperIntegrations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperIntegrations.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataHelperIntegrationUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataHelperIntegrations(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataHelperIntegration(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataHelperIntegrations.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataHelperIntegrationUpdated(item);
                this.context.TblDataHelperIntegrations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperIntegrations.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataHelperIntegrationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnAfterTblDataHelperIntegrationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item)
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

                this.OnTblDataHelperIntegrationCreated(item);
                this.context.TblDataHelperIntegrations.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataHelperIntegrations.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataHelperIntegrationCreated(item);

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
