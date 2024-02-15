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
    [Route("odata/Throttle_Core_Activity/TblMessageSettings")]
    public partial class TblMessageSettingsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageSettingsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> GetTblMessageSettings()
        {
            var items = this.context.TblMessageSettings.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>();
            this.OnTblMessageSettingsRead(ref items);

            return items;
        }

        partial void OnTblMessageSettingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> items);

        partial void OnTblMessageSettingGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageSettings(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> GetTblMessageSetting(int key)
        {
            var items = this.context.TblMessageSettings.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageSettingGet(ref result);

            return result;
        }
        partial void OnTblMessageSettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnAfterTblMessageSettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageSettings(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageSetting(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageSettings
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageSettingDeleted(item);
                this.context.TblMessageSettings.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageSettingDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageSettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnAfterTblMessageSettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageSettings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageSetting(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item)
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
                this.OnTblMessageSettingUpdated(item);
                this.context.TblMessageSettings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageSettings.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageSettingUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageSettings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageSetting(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageSettings.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageSettingUpdated(item);
                this.context.TblMessageSettings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageSettings.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageSettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnAfterTblMessageSettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item)
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

                this.OnTblMessageSettingCreated(item);
                this.context.TblMessageSettings.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageSettings.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageSettingCreated(item);

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
