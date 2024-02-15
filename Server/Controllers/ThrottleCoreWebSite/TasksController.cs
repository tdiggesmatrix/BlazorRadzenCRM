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
    [Route("odata/Throttle_Core_WebSite/Tasks")]
    public partial class TasksController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public TasksController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> GetTasks()
        {
            var items = this.context.Tasks.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>();
            this.OnTasksRead(ref items);

            return items;
        }

        partial void OnTasksRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> items);

        partial void OnTaskGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/Tasks(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> GetTask(int key)
        {
            var items = this.context.Tasks.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnTaskGet(ref result);

            return result;
        }
        partial void OnTaskDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnAfterTaskDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);

        [HttpDelete("/odata/Throttle_Core_WebSite/Tasks(Id={Id})")]
        public IActionResult DeleteTask(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Tasks
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTaskDeleted(item);
                this.context.Tasks.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTaskDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTaskUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnAfterTaskUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);

        [HttpPut("/odata/Throttle_Core_WebSite/Tasks(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTask(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item)
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
                this.OnTaskUpdated(item);
                this.context.Tasks.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Tasks.Where(i => i.Id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Opportunity,TaskStatus,TaskType");
                this.OnAfterTaskUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/Tasks(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTask(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Tasks.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTaskUpdated(item);
                this.context.Tasks.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Tasks.Where(i => i.Id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Opportunity,TaskStatus,TaskType");
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTaskCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnAfterTaskCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item)
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

                this.OnTaskCreated(item);
                this.context.Tasks.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Tasks.Where(i => i.Id == item.Id);

                Request.QueryString = Request.QueryString.Add("$expand", "Opportunity,TaskStatus,TaskType");

                this.OnAfterTaskCreated(item);

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
