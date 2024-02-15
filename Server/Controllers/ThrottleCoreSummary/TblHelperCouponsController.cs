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
    [Route("odata/Throttle_Core_Summary/TblHelperCoupons")]
    public partial class TblHelperCouponsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblHelperCouponsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> GetTblHelperCoupons()
        {
            var items = this.context.TblHelperCoupons.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>();
            this.OnTblHelperCouponsRead(ref items);

            return items;
        }

        partial void OnTblHelperCouponsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> items);

        partial void OnTblHelperCouponGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblHelperCoupons(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> GetTblHelperCoupon(long key)
        {
            var items = this.context.TblHelperCoupons.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblHelperCouponGet(ref result);

            return result;
        }
        partial void OnTblHelperCouponDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnAfterTblHelperCouponDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblHelperCoupons(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblHelperCoupon(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblHelperCoupons
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblHelperCouponDeleted(item);
                this.context.TblHelperCoupons.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblHelperCouponDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperCouponUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnAfterTblHelperCouponUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);

        [HttpPut("/odata/Throttle_Core_Summary/TblHelperCoupons(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblHelperCoupon(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item)
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
                this.OnTblHelperCouponUpdated(item);
                this.context.TblHelperCoupons.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperCoupons.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblHelperCouponUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblHelperCoupons(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblHelperCoupon(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblHelperCoupons.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblHelperCouponUpdated(item);
                this.context.TblHelperCoupons.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperCoupons.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperCouponCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnAfterTblHelperCouponCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item)
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

                this.OnTblHelperCouponCreated(item);
                this.context.TblHelperCoupons.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperCoupons.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblHelperCouponCreated(item);

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
