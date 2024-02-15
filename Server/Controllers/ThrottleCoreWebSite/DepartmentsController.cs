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
    [Route("odata/Throttle_Core_WebSite/Departments")]
    public partial class DepartmentsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public DepartmentsController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> GetDepartments()
        {
            var items = this.context.Departments.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>();
            this.OnDepartmentsRead(ref items);

            return items;
        }

        partial void OnDepartmentsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> items);

        partial void OnDepartmentGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/Departments(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> GetDepartment(int key)
        {
            var items = this.context.Departments.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnDepartmentGet(ref result);

            return result;
        }
        partial void OnDepartmentDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnAfterDepartmentDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);

        [HttpDelete("/odata/Throttle_Core_WebSite/Departments(Id={Id})")]
        public IActionResult DeleteDepartment(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Departments
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnDepartmentDeleted(item);
                this.context.Departments.Remove(item);
                this.context.SaveChanges();
                this.OnAfterDepartmentDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDepartmentUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnAfterDepartmentUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);

        [HttpPut("/odata/Throttle_Core_WebSite/Departments(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutDepartment(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item)
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
                this.OnDepartmentUpdated(item);
                this.context.Departments.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Departments.Where(i => i.Id == key);
                
                this.OnAfterDepartmentUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/Departments(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchDepartment(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Departments.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnDepartmentUpdated(item);
                this.context.Departments.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Departments.Where(i => i.Id == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDepartmentCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnAfterDepartmentCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item)
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

                this.OnDepartmentCreated(item);
                this.context.Departments.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Departments.Where(i => i.Id == item.Id);

                

                this.OnAfterDepartmentCreated(item);

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
