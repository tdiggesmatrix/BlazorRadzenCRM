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
    [Route("odata/Throttle_Core_Activity/TblDataDmSProviders")]
    public partial class TblDataDmSProvidersController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataDmSProvidersController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> GetTblDataDmSProviders()
        {
            var items = this.context.TblDataDmSProviders.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>();
            this.OnTblDataDmSProvidersRead(ref items);

            return items;
        }

        partial void OnTblDataDmSProvidersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> items);

        partial void OnTblDataDmSProviderGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataDmSProviders(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> GetTblDataDmSProvider(int key)
        {
            var items = this.context.TblDataDmSProviders.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataDmSProviderGet(ref result);

            return result;
        }
        partial void OnTblDataDmSProviderDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnAfterTblDataDmSProviderDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataDmSProviders(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataDmSProvider(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataDmSProviders
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataDmSProviderDeleted(item);
                this.context.TblDataDmSProviders.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataDmSProviderDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSProviderUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnAfterTblDataDmSProviderUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataDmSProviders(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataDmSProvider(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item)
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
                this.OnTblDataDmSProviderUpdated(item);
                this.context.TblDataDmSProviders.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSProviders.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataDmSProviderUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataDmSProviders(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataDmSProvider(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataDmSProviders.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataDmSProviderUpdated(item);
                this.context.TblDataDmSProviders.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSProviders.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSProviderCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnAfterTblDataDmSProviderCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item)
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

                this.OnTblDataDmSProviderCreated(item);
                this.context.TblDataDmSProviders.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSProviders.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataDmSProviderCreated(item);

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
