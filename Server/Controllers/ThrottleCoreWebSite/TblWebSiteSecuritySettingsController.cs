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
    [Route("odata/Throttle_Core_WebSite/TblWebSiteSecuritySettings")]
    public partial class TblWebSiteSecuritySettingsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblWebSiteSecuritySettingsController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> GetTblWebSiteSecuritySettings()
        {
            var items = this.context.TblWebSiteSecuritySettings.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>();
            this.OnTblWebSiteSecuritySettingsRead(ref items);

            return items;
        }

        partial void OnTblWebSiteSecuritySettingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> items);

        partial void OnTblWebSiteSecuritySettingGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblWebSiteSecuritySettings(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> GetTblWebSiteSecuritySetting(int key)
        {
            var items = this.context.TblWebSiteSecuritySettings.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblWebSiteSecuritySettingGet(ref result);

            return result;
        }
        partial void OnTblWebSiteSecuritySettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnAfterTblWebSiteSecuritySettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblWebSiteSecuritySettings(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblWebSiteSecuritySetting(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblWebSiteSecuritySettings
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblWebSiteSecuritySettingDeleted(item);
                this.context.TblWebSiteSecuritySettings.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblWebSiteSecuritySettingDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteSecuritySettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnAfterTblWebSiteSecuritySettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblWebSiteSecuritySettings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblWebSiteSecuritySetting(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item)
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
                this.OnTblWebSiteSecuritySettingUpdated(item);
                this.context.TblWebSiteSecuritySettings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteSecuritySettings.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblWebSiteSecuritySettingUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblWebSiteSecuritySettings(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblWebSiteSecuritySetting(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblWebSiteSecuritySettings.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblWebSiteSecuritySettingUpdated(item);
                this.context.TblWebSiteSecuritySettings.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteSecuritySettings.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteSecuritySettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnAfterTblWebSiteSecuritySettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item)
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

                this.OnTblWebSiteSecuritySettingCreated(item);
                this.context.TblWebSiteSecuritySettings.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteSecuritySettings.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblWebSiteSecuritySettingCreated(item);

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
