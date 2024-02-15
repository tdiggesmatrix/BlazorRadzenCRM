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
    [Route("odata/Throttle_Core_Activity/TblDataImportStores")]
    public partial class TblDataImportStoresController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataImportStoresController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> GetTblDataImportStores()
        {
            var items = this.context.TblDataImportStores.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>();
            this.OnTblDataImportStoresRead(ref items);

            return items;
        }

        partial void OnTblDataImportStoresRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> items);

        partial void OnTblDataImportStoreGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataImportStores(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> GetTblDataImportStore(int key)
        {
            var items = this.context.TblDataImportStores.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataImportStoreGet(ref result);

            return result;
        }
        partial void OnTblDataImportStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnAfterTblDataImportStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataImportStores(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataImportStore(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataImportStores
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataImportStoreDeleted(item);
                this.context.TblDataImportStores.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataImportStoreDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataImportStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnAfterTblDataImportStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataImportStores(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataImportStore(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item)
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
                this.OnTblDataImportStoreUpdated(item);
                this.context.TblDataImportStores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataImportStores.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataImportStoreUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataImportStores(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataImportStore(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataImportStores.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataImportStoreUpdated(item);
                this.context.TblDataImportStores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataImportStores.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataImportStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnAfterTblDataImportStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item)
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

                this.OnTblDataImportStoreCreated(item);
                this.context.TblDataImportStores.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataImportStores.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataImportStoreCreated(item);

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
