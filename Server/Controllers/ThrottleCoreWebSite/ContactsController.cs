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
    [Route("odata/Throttle_Core_WebSite/Contacts")]
    public partial class ContactsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public ContactsController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> GetContacts()
        {
            var items = this.context.Contacts.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>();
            this.OnContactsRead(ref items);

            return items;
        }

        partial void OnContactsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> items);

        partial void OnContactGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/Contacts(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> GetContact(int key)
        {
            var items = this.context.Contacts.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnContactGet(ref result);

            return result;
        }
        partial void OnContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnAfterContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);

        [HttpDelete("/odata/Throttle_Core_WebSite/Contacts(Id={Id})")]
        public IActionResult DeleteContact(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Contacts
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnContactDeleted(item);
                this.context.Contacts.Remove(item);
                this.context.SaveChanges();
                this.OnAfterContactDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnAfterContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);

        [HttpPut("/odata/Throttle_Core_WebSite/Contacts(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutContact(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != key))
                {
                    return BadRequest();
                }
                this.OnContactUpdated(item);
                this.context.Contacts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Contacts.Where(i => i.Id == key);
                
                this.OnAfterContactUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/Contacts(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchContact(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Contacts.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnContactUpdated(item);
                this.context.Contacts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Contacts.Where(i => i.Id == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnAfterContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item)
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

                this.OnContactCreated(item);
                this.context.Contacts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Contacts.Where(i => i.Id == item.Id);

                

                this.OnAfterContactCreated(item);

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
