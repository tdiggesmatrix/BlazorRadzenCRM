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
    [Route("odata/Throttle_Core_WebSite/TblWebSiteLanguages")]
    public partial class TblWebSiteLanguagesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TblWebSiteLanguagesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> GetTblWebSiteLanguages()
        {
            var items = this.context.TblWebSiteLanguages.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>();
            this.OnTblWebSiteLanguagesRead(ref items);

            return items;
        }

        partial void OnTblWebSiteLanguagesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> items);

        partial void OnTblWebSiteLanguageGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TblWebSiteLanguages(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> GetTblWebSiteLanguage(int key)
        {
            var items = this.context.TblWebSiteLanguages.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblWebSiteLanguageGet(ref result);

            return result;
        }
        partial void OnTblWebSiteLanguageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnAfterTblWebSiteLanguageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TblWebSiteLanguages(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblWebSiteLanguage(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblWebSiteLanguages
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblWebSiteLanguageDeleted(item);
                this.context.TblWebSiteLanguages.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblWebSiteLanguageDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteLanguageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnAfterTblWebSiteLanguageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);

        [HttpPut("/odata/Throttle_Core_WebSite/TblWebSiteLanguages(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblWebSiteLanguage(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item)
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
                this.OnTblWebSiteLanguageUpdated(item);
                this.context.TblWebSiteLanguages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteLanguages.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblWebSiteLanguageUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TblWebSiteLanguages(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblWebSiteLanguage(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblWebSiteLanguages.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblWebSiteLanguageUpdated(item);
                this.context.TblWebSiteLanguages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteLanguages.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblWebSiteLanguageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnAfterTblWebSiteLanguageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item)
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

                this.OnTblWebSiteLanguageCreated(item);
                this.context.TblWebSiteLanguages.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblWebSiteLanguages.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblWebSiteLanguageCreated(item);

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
