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
    [Route("odata/Throttle_Core_WebSite/Employees")]
    public partial class EmployeesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context;

        public EmployeesController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> GetEmployees()
        {
            var items = this.context.Employees.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>();
            this.OnEmployeesRead(ref items);

            return items;
        }

        partial void OnEmployeesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> items);

        partial void OnEmployeeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_WebSite/Employees(Id={Id})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> GetEmployee(int key)
        {
            var items = this.context.Employees.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnEmployeeGet(ref result);

            return result;
        }
        partial void OnEmployeeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnAfterEmployeeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);

        [HttpDelete("/odata/Throttle_Core_WebSite/Employees(Id={Id})")]
        public IActionResult DeleteEmployee(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Employees
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnEmployeeDeleted(item);
                this.context.Employees.Remove(item);
                this.context.SaveChanges();
                this.OnAfterEmployeeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnEmployeeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnAfterEmployeeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);

        [HttpPut("/odata/Throttle_Core_WebSite/Employees(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutEmployee(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item)
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
                this.OnEmployeeUpdated(item);
                this.context.Employees.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Employees.Where(i => i.Id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Department");
                this.OnAfterEmployeeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_WebSite/Employees(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchEmployee(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Employees.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnEmployeeUpdated(item);
                this.context.Employees.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Employees.Where(i => i.Id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Department");
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnEmployeeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnAfterEmployeeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item)
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

                this.OnEmployeeCreated(item);
                this.context.Employees.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Employees.Where(i => i.Id == item.Id);

                Request.QueryString = Request.QueryString.Add("$expand", "Department");

                this.OnAfterEmployeeCreated(item);

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
