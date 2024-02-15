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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Customer
{
    [Route("odata/Throttle_Core_Customer/TblCustomerContacts")]
    public partial class TblCustomerContactsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context;

        public TblCustomerContactsController(ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> GetTblCustomerContacts()
        {
            var items = this.context.TblCustomerContacts.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>();
            this.OnTblCustomerContactsRead(ref items);

            return items;
        }

        partial void OnTblCustomerContactsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> items);

        partial void OnTblCustomerContactGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Customer/TblCustomerContacts(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> GetTblCustomerContact(int key)
        {
            var items = this.context.TblCustomerContacts.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCustomerContactGet(ref result);

            return result;
        }
        partial void OnTblCustomerContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnAfterTblCustomerContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);

        [HttpDelete("/odata/Throttle_Core_Customer/TblCustomerContacts(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCustomerContact(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCustomerContacts
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCustomerContactDeleted(item);
                this.context.TblCustomerContacts.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCustomerContactDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnAfterTblCustomerContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);

        [HttpPut("/odata/Throttle_Core_Customer/TblCustomerContacts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCustomerContact(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item)
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
                this.OnTblCustomerContactUpdated(item);
                this.context.TblCustomerContacts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerContacts.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCustomerContactUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Customer/TblCustomerContacts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCustomerContact(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCustomerContacts.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCustomerContactUpdated(item);
                this.context.TblCustomerContacts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerContacts.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCustomerContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnAfterTblCustomerContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item)
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

                this.OnTblCustomerContactCreated(item);
                this.context.TblCustomerContacts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCustomerContacts.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCustomerContactCreated(item);

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
