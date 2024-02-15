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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Summary
{
    [Route("odata/Throttle_Core_Summary/TblHelperMailAddressErrors")]
    public partial class TblHelperMailAddressErrorsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblHelperMailAddressErrorsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> GetTblHelperMailAddressErrors()
        {
            var items = this.context.TblHelperMailAddressErrors.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>();
            this.OnTblHelperMailAddressErrorsRead(ref items);

            return items;
        }

        partial void OnTblHelperMailAddressErrorsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> items);

        partial void OnTblHelperMailAddressErrorGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblHelperMailAddressErrors(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> GetTblHelperMailAddressError(int key)
        {
            var items = this.context.TblHelperMailAddressErrors.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblHelperMailAddressErrorGet(ref result);

            return result;
        }
        partial void OnTblHelperMailAddressErrorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnAfterTblHelperMailAddressErrorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblHelperMailAddressErrors(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblHelperMailAddressError(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblHelperMailAddressErrors
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblHelperMailAddressErrorDeleted(item);
                this.context.TblHelperMailAddressErrors.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblHelperMailAddressErrorDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperMailAddressErrorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnAfterTblHelperMailAddressErrorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);

        [HttpPut("/odata/Throttle_Core_Summary/TblHelperMailAddressErrors(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblHelperMailAddressError(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item)
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
                this.OnTblHelperMailAddressErrorUpdated(item);
                this.context.TblHelperMailAddressErrors.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperMailAddressErrors.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblHelperMailAddressErrorUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblHelperMailAddressErrors(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblHelperMailAddressError(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblHelperMailAddressErrors.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblHelperMailAddressErrorUpdated(item);
                this.context.TblHelperMailAddressErrors.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperMailAddressErrors.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperMailAddressErrorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnAfterTblHelperMailAddressErrorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item)
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

                this.OnTblHelperMailAddressErrorCreated(item);
                this.context.TblHelperMailAddressErrors.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperMailAddressErrors.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblHelperMailAddressErrorCreated(item);

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
