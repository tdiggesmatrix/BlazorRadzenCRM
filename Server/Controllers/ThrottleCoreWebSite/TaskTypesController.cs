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
    [Route("odata/Throttle_Core_WebSite/TaskTypes")]
    public partial class TaskTypesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TaskTypesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> GetTaskTypes()
        {
            var items = this.context.TaskTypes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>();
            this.OnTaskTypesRead(ref items);

            return items;
        }

        partial void OnTaskTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> items);

        partial void OnTaskTypeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TaskTypes(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> GetTaskType(int key)
        {
            var items = this.context.TaskTypes.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnTaskTypeGet(ref result);

            return result;
        }
        partial void OnTaskTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnAfterTaskTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TaskTypes(Id={Id})")]
        public IActionResult DeleteTaskType(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TaskTypes
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTaskTypeDeleted(item);
                this.context.TaskTypes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTaskTypeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTaskTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnAfterTaskTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);

        [HttpPut("/odata/Throttle_Core_WebSite/TaskTypes(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTaskType(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item)
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
                this.OnTaskTypeUpdated(item);
                this.context.TaskTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TaskTypes.Where(i => i.Id == key);
                
                this.OnAfterTaskTypeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TaskTypes(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTaskType(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TaskTypes.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTaskTypeUpdated(item);
                this.context.TaskTypes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TaskTypes.Where(i => i.Id == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTaskTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnAfterTaskTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item)
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

                this.OnTaskTypeCreated(item);
                this.context.TaskTypes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TaskTypes.Where(i => i.Id == item.Id);

                

                this.OnAfterTaskTypeCreated(item);

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
