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
    [Route("odata/Throttle_Core_WebSite/TaskStatuses")]
    public partial class TaskStatusesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TaskStatusesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> GetTaskStatuses()
        {
            var items = this.context.TaskStatuses.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>();
            this.OnTaskStatusesRead(ref items);

            return items;
        }

        partial void OnTaskStatusesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> items);

        partial void OnTaskStatusGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/TaskStatuses(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> GetTaskStatus(int key)
        {
            var items = this.context.TaskStatuses.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnTaskStatusGet(ref result);

            return result;
        }
        partial void OnTaskStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnAfterTaskStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);

        [HttpDelete("/odata/Throttle_Core_WebSite/TaskStatuses(Id={Id})")]
        public IActionResult DeleteTaskStatus(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TaskStatuses
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTaskStatusDeleted(item);
                this.context.TaskStatuses.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTaskStatusDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTaskStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnAfterTaskStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);

        [HttpPut("/odata/Throttle_Core_WebSite/TaskStatuses(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTaskStatus(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item)
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
                this.OnTaskStatusUpdated(item);
                this.context.TaskStatuses.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TaskStatuses.Where(i => i.Id == key);
                
                this.OnAfterTaskStatusUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/TaskStatuses(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTaskStatus(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TaskStatuses.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTaskStatusUpdated(item);
                this.context.TaskStatuses.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TaskStatuses.Where(i => i.Id == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTaskStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnAfterTaskStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item)
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

                this.OnTaskStatusCreated(item);
                this.context.TaskStatuses.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TaskStatuses.Where(i => i.Id == item.Id);

                

                this.OnAfterTaskStatusCreated(item);

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
